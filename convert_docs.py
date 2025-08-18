# convert_docs.py (Gemini API 버전)
import os
import google.generativeai as genai # 변경된 부분: 라이브러리 변경
from lxml import etree

# 1. 환경변수에서 Gemini API 키 가져오기
api_key = os.getenv("GEMINI_API_KEY") # 변경된 부분: 환경 변수 이름
if not api_key:
    raise ValueError("Gemini API 키가 설정되지 않았습니다. GEMINI_API_KEY 환경변수를 확인하세요.")

genai.configure(api_key=api_key) # 변경된 부분: API 키 설정 방식

# 2. Doxygen XML 파일에서 데이터 추출하기 (이 부분은 변경 없음)
def parse_doxygen_xml():
    try:
        tree = etree.parse('xml/index.xml')
        compounds = tree.xpath('//compound[@kind="class" or @kind="file"]')
        docs_data = []
        class_relationships = []
        
        for compound in compounds:
            name = compound.find('name').text
            refid = compound.get('refid')
            detail_tree = etree.parse(f'xml/{refid}.xml')
            
            # 기본 정보 추출
            brief_description_node = detail_tree.find('.//briefdescription/para')
            brief = brief_description_node.text if brief_description_node is not None else "설명 없음"
            
            # 상속 관계는 제외하고 주요 관계만 추출
            base_classes = []
            base_compoundrefs = detail_tree.xpath('.//basecompoundref')
            for base_ref in base_compoundrefs:
                base_name = base_ref.text
                if base_name:
                    base_classes.append(base_name)
            
            # 주요 관계 추출 (멤버 변수, 함수 매개변수, 반환 타입 등)
            dependencies = []
            
            # 멤버 변수에서 관계 추출
            member_vars = detail_tree.xpath('.//memberdef[@kind="variable"]')
            for var in member_vars:
                var_type_node = var.find('type/ref')
                if var_type_node is not None and var_type_node.text:
                    dep_class = var_type_node.text
                    if dep_class != name:  # 자기 자신 제외
                        dependencies.append(dep_class)
                        class_relationships.append({
                            'from': name,
                            'to': dep_class,
                            'type': 'dependency'
                        })
            
            # 함수 매개변수에서 관계 추출
            functions = detail_tree.xpath('.//memberdef[@kind="function"]')
            for func in functions:
                param_list = func.xpath('.//param/type/ref')
                for param in param_list:
                    if param.text and param.text != name:
                        class_relationships.append({
                            'from': name,
                            'to': param.text,
                            'type': 'dependency'
                        })
            
            # 함수 정보 추출
            member_info = []
            members = detail_tree.xpath('.//memberdef[@kind="function"]')
            for member in members:
                member_name = member.find('name').text
                member_brief_node = member.find('briefdescription/para')
                member_brief = member_brief_node.text if member_brief_node is not None else ""
                member_info.append(f"- 함수 `{member_name}`: {member_brief}")
            
            docs_data.append({
                "name": name, 
                "brief": brief, 
                "members": member_info,
                "base_classes": base_classes,
                "dependencies": dependencies
            })
        
        return docs_data, class_relationships
    except FileNotFoundError:
        print("Doxygen XML 파일을 찾을 수 없습니다. Doxygen을 먼저 실행하세요.")
        return None



# 3. AI에게 README.md 생성을 요청하는 프롬프트 만들기 (이 부분은 변경 없음)
def create_prompt(docs_data, class_relationships):
    # 클래스 관계도 생성을 위한 데이터 분석
    class_names = [data['name'] for data in docs_data]
    
    prompt_content = """당신은 코드 문서를 아주 잘 작성하는 전문가입니다. 아래 프로젝트의 Doxygen에서 추출한 데이터입니다. 이 데이터를 바탕으로 GitHub 사용자들이 이해하기 쉬운 멋진 README.md 파일을 한국어로 작성해주세요.

각 클래스와 주요 함수에 대해 설명하고, 코드 블록을 적절히 사용해서 예쁘게 꾸며주세요. 프로젝트의 전반적인 소개로 시작해주세요.

**중요**: 
1. **카테고리 자동 분류**: 클래스들의 기능과 역할을 분석해서 적절한 카테고리로 자동 분류해주세요. 미리 정의된 카테고리가 없으므로 클래스들의 공통 기능과 역할을 바탕으로 논리적인 카테고리를 만들어주세요.
   - 예시 카테고리: 🎮 게임 로직, 🎯 입력 처리, 🏰 맵/월드, 👤 캐릭터, 🎨 UI/시각적, 🔧 유틸리티 등
   - 클래스 이름과 설명을 바탕으로 가장 적절한 카테고리를 판단해주세요
   - 비슷한 기능을 하는 클래스들을 같은 카테고리로 묶어주세요
2. 각 기능 카테고리별로 <details> 태그를 사용해서 토글 목록을 만들어주세요
3. 각 클래스는 해당 카테고리 안에 포함시켜주세요
4. 각 클래스의 기능과 역할을 명확하게 설명해주세요
5. 각 카테고리 앞에 적절한 이모지를 추가해주세요 (예: 🎮, 🎯, 🏰 등)
6. **클래스 관계도 섹션을 추가해주세요**: 아래 클래스 관계 정보를 바탕으로 Mermaid 다이어그램을 사용하여 클래스 간의 관계를 시각적으로 표현해주세요.
7. **프로젝트 구조 섹션을 추가해주세요**: 주요 폴더와 파일들의 역할을 설명해주세요


**클래스 관계도 요구사항**:
- Mermaid 문법을 사용하여 클래스 다이어그램을 생성해주세요
- **상속 관계는 제외하고 주요 클래스들 간의 관계만 표시해주세요**
- 의존성 관계는 `-->` 화살표로 표시해주세요 (한 클래스가 다른 클래스를 사용하는 경우)
- 연관 관계는 `--` 선으로 표시해주세요 (클래스들이 서로 연관되어 있는 경우)
- 각 클래스의 주요 역할을 간단히 표시해주세요
- 다이어그램은 "## 📊 클래스 관계도" 섹션에 포함시켜주세요
- 기본적인 함수 내용은 필요없고 핵심적인 내용만 넣어서 표시해주세요
- **중요**: 클래스 이름에 특수문자(:, -, 공백 등)가 포함된 경우 따옴표로 감싸주세요
- **중요**: Mermaid 문법에 맞게 정확한 형식을 사용해주세요
- **중요**: 각 클래스는 대괄호로 감싸주세요 (예: [ClassName])
- **Mermaid 예시**:
  ```mermaid
  classDiagram
    [GameManager] --> [PlayerController] : 관리
    [PlayerController] --> [EnemyBase] : 공격
    [Camera] --> [PlayerController] : 추적
    [Spawner] --> [EnemyBase] : 생성
  ```

**README 구조 요구사항**:
- 프로젝트 제목과 간단한 설명으로 시작
- 주요 기능들을 불릿 포인트로 나열
- 설치 및 실행 방법 (단계별 가이드)
- 프로젝트 구조 설명
- 클래스 관계도 (Mermaid 다이어그램)
- 주요 클래스별 상세 설명 (카테고리별 분류)
- 기여 방법
- 라이선스 정보

**프로젝트 클래스 목록**:
"""
    
    # 클래스 목록 추가
    for i, name in enumerate(class_names, 1):
        prompt_content += f"{i}. {name}\n"
    
    # 클래스 관계 정보 추가
    prompt_content += "\n**클래스 관계 정보**:\n"
    if class_relationships:
        for rel in class_relationships:
            if rel['type'] == 'dependency':
                prompt_content += f"- {rel['from']} 의존 → {rel['to']}\n"
    else:
        prompt_content += "- 분석된 관계 정보가 없습니다. 클래스 이름과 설명을 바탕으로 추론해주세요.\n"
    
    prompt_content += "\n**Mermaid 다이어그램 생성 시 주의사항**:\n"
    prompt_content += "- 클래스 이름에 특수문자가 있으면 따옴표로 감싸주세요\n"
    prompt_content += "- 정확한 Mermaid 문법을 사용해주세요\n"
    prompt_content += "- classDiagram 키워드로 시작해주세요\n"
    
    prompt_content += "\n[추출된 문서 데이터]\n"
    for data in docs_data:
        prompt_content += f"\n<details>\n<summary><b>📁 {data['name']}</b></summary>\n\n"
        prompt_content += f"**설명**: {data['brief']}\n\n"
        prompt_content += "**주요 함수**:\n"
        for member in data['members']:
            prompt_content += f"• {member}\n"
        prompt_content += "\n</details>\n"
    return prompt_content
    
# 4. Gemini API 호출 및 README.md 파일 작성 (API 호출 부분 전체 변경)
def generate_readme(prompt):
    print("Gemini API를 호출하여 README.md 생성을 시작합니다...")
    try:
        # 변경된 부분: Gemini 모델 초기화
        model = genai.GenerativeModel('gemini-1.5-pro-latest') 
        
        # 변경된 부분: 콘텐츠 생성 및 응답 처리
        response = model.generate_content(prompt)
        content = response.text

        with open("README.md", "w", encoding="utf-8") as f:
            f.write(content)
        print("README.md 파일이 성공적으로 생성되었습니다!")
    except Exception as e:
        print(f"API 호출 중 오류 발생: {e}")

# 5. 메인 실행 로직 (이 부분은 변경 없음)
if __name__ == "__main__":
    result = parse_doxygen_xml()
    if result:
        doxygen_data, class_relationships = result
        final_prompt = create_prompt(doxygen_data, class_relationships)
        generate_readme(final_prompt)