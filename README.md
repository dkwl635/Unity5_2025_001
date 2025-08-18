# 🎮 던전 탐험 게임 프로젝트

이 프로젝트는 유니티 엔진을 사용하여 개발된 간단한 2D 던전 탐험 게임입니다. 플레이어는 캐릭터를 조작하여 던전을 탐험하고, 적과 전투를 벌입니다. 게임의 핵심 기능은 다음과 같습니다:

- **캐릭터 이동 및 조작**: 플레이어는 입력을 통해 캐릭터를 이동하고 상호작용할 수 있습니다.
- **적 AI**: 적들은 플레이어를 추적하고 공격합니다.
- **카메라 시스템**: 카메라는 플레이어 캐릭터를 따라 부드럽게 이동합니다.
- **오브젝트 풀링**: 오브젝트 풀링을 사용하여 게임 성능을 최적화합니다.
- **게임 모드 관리**: 다양한 게임 모드를 지원하도록 설계되었습니다.

## ✨ 주요 기능

- 플레이어 캐릭터 이동 및 조작
- 적 AI 및 전투
- 동적 카메라 시스템
- 효율적인 오브젝트 풀링 시스템
- 확장 가능한 게임 모드 관리 시스템

## 🚀 설치 및 실행 방법

1. 이 저장소를 클론합니다.
2. Unity Hub에서 프로젝트를 엽니다.
3. Unity 에디터에서 Play 버튼을 누릅니다.


## 📂 프로젝트 구조

- `Scripts/`: 게임 로직을 담은 C# 스크립트 파일들이 위치합니다.
- `Prefabs/`: 게임 오브젝트 프리팹들이 위치합니다.
- `Scenes/`: 게임 씬 파일들이 위치합니다.


## 📊 클래스 관계도

```mermaid
classDiagram
    "GameManager" --> "GameMode" : 관리
    "GameMode" --> "PlayerController" : 생성 및 연결
    "GameMode" --> "CharacterBase" : 생성 및 연결
    "PlayerController" --> "CharacterBase" : 조작
    "CharacterBase" --> "SpriteController" : 애니메이션 제어
    "EnemyBase" --> "SpriteController" : 애니메이션 제어
    "Spawner" --> "PoolManager" : 오브젝트 생성
    "SetCameraTarget" --> "PlayerController" : 타겟 설정
    "EnemyBase" --> "CharacterBase" : 상속 (제외)
    "DungeonGameMode" --> "GameMode" : 상속 (제외)
```

<details>
<summary>🎮 게임 로직</summary>

<details>
<summary><code>GameManager</code></summary>

게임의 전역 상태를 관리하는 싱글톤 매니저입니다. 현재 게임 모드를 관리하고 다른 시스템에서 접근할 수 있도록 합니다.
</details>

<details>
<summary><code>GameMode</code></summary>

플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.
</details>

<details>
<summary><code>DungeonGameMode</code></summary>

던전 게임 모드를 관리하는 클래스입니다. `GameMode`를 상속받아 던전 특화 기능을 제공합니다.
</details>

</details>

<details>
<summary>🎯 입력 처리</summary>

<details>
<summary><code>PlayerController</code></summary>

이동 입력을 받아 캐릭터에 전달합니다.
</details>

</details>

<details>
<summary>👤 캐릭터</summary>

<details>
<summary><code>CharacterBase</code></summary>

이동 입력을 받아 처리하는 기본 클래스입니다.
</details>

<details>
<summary><code>EnemyBase</code></summary>

적의 이동 로직을 처리합니다. `CharacterBase`를 상속받습니다.
</details>

</details>

<details>
<summary>🎨 UI/시각적</summary>

<details>
<summary><code>SpriteController</code></summary>

애니메이션과 스프라이트 방향을 업데이트합니다.
</details>

<details>
<summary><code>SetCameraTarget</code></summary>

Cinemachine 카메라의 타겟을 설정하는 클래스입니다. 플레이어 캐릭터를 카메라의 추적 대상으로 설정합니다.
</details>

</details>

<details>
<summary>🔧 유틸리티</summary>

<details>
<summary><code>PoolManager</code></summary>

지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다. 오브젝트 풀링을 관리합니다.
</details>

<details>
<summary><code>Spawner</code></summary>

플레이어를 찾아 스포너의 부모로 설정하고, 랜덤한 위치에 적을 생성합니다.
</details>

<details>
<summary><code>Reposition</code></summary>

트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.
</details>

</details>


## 🙌 기여 방법

프로젝트에 기여하고 싶으시면, 이슈를 제기하거나 풀 리퀘스트를 보내주세요.

## 📄 라이선스

MIT 라이선스
