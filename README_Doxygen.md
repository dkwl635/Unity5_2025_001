# Unity 프로젝트 스크립트 문서화 가이드

## 📋 개요
이 프로젝트는 Unity C# 스크립트 파일들을 Doxygen을 사용하여 자동으로 문서화합니다.

## 🚀 사용법

### 1. Doxygen 설치
- [Doxygen 공식 사이트](https://www.doxygen.nl/download.html)에서 Doxygen을 다운로드하여 설치
- Windows의 경우 설치 후 시스템 PATH에 추가

### 2. 문서 생성
프로젝트 루트 디렉토리에서 다음 중 하나를 실행:

#### 방법 1: 배치 파일 사용 (권장)
```bash
generate_docs.bat
```

#### 방법 2: 직접 명령어 실행
```bash
doxygen Doxyfile
```

### 3. 문서 확인
생성된 문서는 `Documentation/html/index.html`에서 확인할 수 있습니다.

## 📁 설정된 경로

### 입력 디렉토리
- `Assets/Script/` - Unity 스크립트 파일들

### 제외 디렉토리
- `Assets/Script/Editor/` - Unity 에디터 스크립트
- `Assets/Script/Plugins/` - 플러그인 스크립트
- `Assets/Script/ThirdParty/` - 서드파티 스크립트

### 출력 디렉토리
- `Documentation/` - 생성된 문서 파일들

## 📝 C# 스크립트 문서화 예시

### 클래스 문서화
```csharp
/// <summary>
/// 플레이어 캐릭터를 제어하는 클래스
/// </summary>
/// <remarks>
/// 이 클래스는 플레이어의 이동, 점프, 공격 등의 기능을 담당합니다.
/// </remarks>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 이동 속도
    /// </summary>
    [SerializeField] private float moveSpeed = 5f;
    
    /// <summary>
    /// 플레이어를 이동시킵니다
    /// </summary>
    /// <param name="direction">이동할 방향 벡터</param>
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
```

### 함수 문서화
```csharp
/// <summary>
/// 적을 공격하는 함수
/// </summary>
/// <param name="target">공격할 대상</param>
/// <param name="damage">공격력</param>
/// <returns>공격 성공 여부</returns>
/// <exception cref="System.ArgumentNullException">target이 null인 경우</exception>
public bool AttackEnemy(Enemy target, int damage)
{
    if (target == null)
        throw new ArgumentNullException(nameof(target));
        
    return target.TakeDamage(damage);
}
```

## ⚙️ 주요 설정

### 활성화된 기능
- ✅ HTML 출력 (웹 브라우저에서 확인 가능)
- ✅ LaTeX 출력 (PDF 생성 가능)
- ✅ XML 출력 (다른 도구에서 활용 가능)
- ✅ 재귀 검색 (하위 폴더까지 검색)
- ✅ Unity 플랫폼 매크로 지원

### 파일 패턴
- `*.cs` - C# 스크립트 파일
- 기타 C++, Java, Python 등 지원

## 🔧 문제 해결

### Doxygen이 설치되지 않은 경우
1. [Doxygen 다운로드 페이지](https://www.doxygen.nl/download.html)에서 설치
2. 설치 후 시스템 재시작
3. 명령 프롬프트에서 `doxygen --version` 실행하여 설치 확인

### 문서가 생성되지 않는 경우
1. `Assets/Script/` 폴더에 C# 파일이 있는지 확인
2. C# 파일에 적절한 주석이 있는지 확인
3. Doxyfile이 프로젝트 루트에 있는지 확인

### Unity 에디터 스크립트도 문서화하고 싶은 경우
Doxyfile에서 EXCLUDE 설정을 수정하거나 제거하세요.

## 📚 추가 정보
- [Doxygen 공식 문서](https://www.doxygen.nl/manual/index.html)
- [C# XML 문서 주석](https://docs.microsoft.com/ko-kr/dotnet/csharp/codedoc)
