# convert_docs_simple.py (API 할당량 문제 우회용)
import os
from lxml import etree

def parse_doxygen_xml():
    try:
        tree = etree.parse('Documentation/xml/index.xml')
        compounds = tree.xpath('//compound[@kind="class" or @kind="file"]')
        docs_data = []
        for compound in compounds:
            name = compound.find('name').text
            refid = compound.get('refid')
            detail_tree = etree.parse(f'Documentation/xml/{refid}.xml')
            brief_description_node = detail_tree.find('.//briefdescription/para')
            brief = brief_description_node.text if brief_description_node is not None else "설명 없음"
            member_info = []
            members = detail_tree.xpath('.//memberdef[@kind="function"]')
            for member in members:
                member_name = member.find('name').text
                member_brief_node = member.find('briefdescription/para')
                member_brief = member_brief_node.text if member_brief_node is not None else ""
                member_info.append(f"- 함수 `{member_name}`: {member_brief}")
            docs_data.append({"name": name, "brief": brief, "members": member_info})
        return docs_data
    except FileNotFoundError:
        print("Doxygen XML 파일을 찾을 수 없습니다. Doxygen을 먼저 실행하세요.")
        return None

def generate_simple_readme(docs_data):
    print("간단한 README.md 생성을 시작합니다...")
    
    content = """# Unity 프로젝트 문서

이 프로젝트는 Unity로 개발된 게임 프로젝트입니다.

## 프로젝트 구조

### 주요 클래스 및 파일

"""
    
    for data in docs_data:
        content += f"#### {data['name']}\n"
        content += f"**설명**: {data['brief']}\n\n"
        
        if data['members']:
            content += "**주요 함수**:\n"
            for member in data['members']:
                content += f"{member}\n"
            content += "\n"
    
    content += """
## 설치 및 실행

1. Unity Hub에서 프로젝트를 열어주세요
2. Unity 버전: 2022.3 LTS 이상 권장
3. 프로젝트를 빌드하고 실행하세요

## 라이선스

이 프로젝트는 MIT 라이선스 하에 배포됩니다.
"""
    
    with open("README.md", "w", encoding="utf-8") as f:
        f.write(content)
    print("README.md 파일이 성공적으로 생성되었습니다!")

if __name__ == "__main__":
    doxygen_data = parse_doxygen_xml()
    if doxygen_data:
        generate_simple_readme(doxygen_data)
    else:
        print("Doxygen 데이터를 가져올 수 없습니다.")
