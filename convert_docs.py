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
        
        for compound in compounds:
            name = compound.find('name').text
            refid = compound.get('refid')
            detail_tree = etree.parse(f'xml/{refid}.xml')
            
            # 기본 정보 추출
            brief_description_node = detail_tree.find('.//briefdescription/para')
            brief = brief_description_node.text if brief_description_node is not None else "설명 없음"
            
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
                "members": member_info
            })
        
        return docs_data
    except FileNotFoundError:
        print("Doxygen XML 파일을 찾을 수 없습니다. Doxygen을 먼저 실행하세요.")
        return None

# 3. AI에게 README.md 생성을 요청하는 프롬프트 만들기
def create_prompt(docs_data):
    # 클래스 목록 추출
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
4. **각 클래스는 <details> 태그를 사용해서 접기/펼치기 형태로 상세 설명을 제공해주세요**
5. 각 카테고리 및 클래스 앞에 적절한 이모지를 추가해주세요 (예: 🎮, 🎯, 🏰 등)
6. **프로젝트 구조 섹션을 추가해주세요**: 주요 폴더와 파일들의 역할을 설명해주세요

**클래스 상세 설명 요구사항**:
- 각 클래스는 <details> 태그로 감싸서 접기/펼치기 형태로 만들어주세요
- 클래스 이름을 <summary> 태그 안에 넣어주세요
- 클래스 설명, 주요 기능, **핵심 함수만** 포함해주세요
- **당연한 함수는 제외**: getter/setter, 기본 생성자, 단순 변수 접근 함수 등은 생략해주세요
- **중요한 비즈니스 로직 함수만** 표시해주세요
- **들여쓰기를 명확하게** 사용해서 가독성을 높여주세요
- 예시:
  ```markdown
  <details>
  <summary>🎮 GameManager</summary>
  
      **역할**: 게임의 전반적인 상태와 로직을 관리
      
      **주요 기능**: 
      - 게임 시작/종료 처리
      - 레벨 관리
      - 점수 시스템
      
      **핵심 함수**:
      - `StartGame()`: 게임 시작 처리
      - `EndGame()`: 게임 종료 처리
      - `UpdateScore()`: 점수 업데이트 로직
  
  </details>
  ```

**README 구조 요구사항**:
- 프로젝트 제목과 간단한 설명으로 시작
- 프로젝트 구조 설명 (주요 폴더와 파일들의 역할)
- 주요 클래스별 상세 설명 (카테고리별 분류)

**프로젝트 클래스 목록**:
"""
    
    # 클래스 목록 추가
    for i, name in enumerate(class_names, 1):
        prompt_content += f"{i}. {name}\n"
    
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
        final_prompt = create_prompt(result)
        generate_readme(final_prompt)