# 🎮 던전 탐험 게임 프로젝트

이 프로젝트는 유니티 엔진을 사용하여 개발된 간단한 2D 던전 탐험 게임입니다. 플레이어는 캐릭터를 조작하여 던전을 탐험하고, 적과 전투를 벌입니다. 게임의 핵심 기능은 다음과 같습니다:

- 플레이어 이동 및 조작
- 적 AI 및 전투
- 카메라 제어
- 오브젝트 풀링 시스템
- 게임 모드 관리

## ✨ 주요 기능

- 🎮 **캐릭터 움직임**: WASD 또는 방향키로 캐릭터를 조작하여 던전을 탐험합니다.
- 👾 **적 AI**: 적들은 플레이어를 추적하고 공격합니다.
- 🎥 **카메라 추적**: 카메라는 플레이어 캐릭터를 따라 부드럽게 움직입니다.
- ♻️ **오브젝트 풀링**: 효율적인 메모리 관리를 위해 오브젝트 풀링 시스템을 사용합니다.
- 🔄 **게임 모드 관리**: 다양한 게임 모드를 지원하고 전환할 수 있습니다.


## 🚀 설치 및 실행

1. 이 저장소를 클론합니다.
2. 유니티 엔진에서 프로젝트를 엽니다.
3. 게임 씬을 열고 실행 버튼을 누릅니다.


## 📂 프로젝트 구조

- **Scripts**: 게임 로직을 담당하는 C# 스크립트 파일들이 위치합니다.
- **Prefabs**: 게임 오브젝트 프리팹들이 저장됩니다.
- **Scenes**: 게임 씬 파일들이 위치합니다.


## 📊 클래스 관계도

```mermaid
graph LR
    classDiagram
        MonoBehaviour --|> CharacterBase : 상속
        CharacterBase --> PlayerController : 의존
        CharacterBase --> SpriteController : 의존
        MonoBehaviour --|> DungeonGameMode : 상속
        DungeonGameMode --|> GameMode : 상속
        MonoBehaviour --|> EnemyBase : 상속
        EnemyBase --> SpriteController : 의존
        MonoBehaviour --|> GameManager : 상속
        GameManager --> GameMode : 의존
        MonoBehaviour --|> GameMode : 상속
        GameMode --> PlayerController : 의존
        GameMode --> CharacterBase : 의존
        MonoBehaviour --|> PlayerController : 상속
        PlayerController --> CharacterBase : 의존
        MonoBehaviour --|> PoolManager : 상속
        MonoBehaviour --|> Reposition : 상속
        MonoBehaviour --|> SetCameraTarget : 상속
        MonoBehaviour --|> Spawner : 상속
        Spawner --> PoolManager : 의존
        MonoBehaviour --|> SpriteController : 상속
```

<details>
<summary> 🎮 게임 로직 </summary>

### 🎮 GameManager
게임의 전역 상태를 관리하는 싱글톤 매니저입니다. 현재 게임 모드를 관리하고 다른 시스템에서 접근할 수 있도록 합니다.

### 🎮 GameMode
플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.

### 🎮 DungeonGameMode
던전 게임 모드를 관리하는 클래스입니다. GameMode를 상속받아 던전 특화 기능을 제공합니다.


</details>

<details>
<summary> 🎯 입력 처리 </summary>

### 🎯 PlayerController
이동 입력을 받아 캐릭터에 전달합니다.

</details>

<details>
<summary> 👤 캐릭터 </summary>

### 👤 CharacterBase
이동 입력을 받아 처리하는 기본 클래스입니다.

### 👤 EnemyBase
적의 이동 로직을 처리합니다.


</details>

<details>
<summary> 🎨 UI/시각적 </summary>

### 🎨 SpriteController
애니메이션과 스프라이트 방향을 업데이트합니다.

### 🎨 SetCameraTarget
Cinemachine 카메라의 타겟을 설정하는 클래스입니다. 플레이어 캐릭터를 카메라의 추적 대상으로 설정합니다.

</details>

<details>
<summary> 🔧 유틸리티 </summary>

### 🔧 PoolManager
지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다.

### 🔧 Reposition
트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.

### 🔧 Spawner
플레이어를 찾아 스포너의 부모로 설정하고, 랜덤한 위치에 적을 생성합니다.

</details>


## ⌨️ 사용법 예제

```C#
// PlayerController를 사용하여 캐릭터 이동
PlayerController playerController = FindObjectOfType<PlayerController>();
playerController.OnMove(new Vector2(1, 0)); // 오른쪽으로 이동
```


## 🤝 기여 방법

이 프로젝트에 기여하고 싶으시면, 이슈를 제기하거나 풀 리퀘스트를 보내주세요.


## 📜 라이선스

MIT 라이선스
