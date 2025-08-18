# 🎮 던전 탐험 게임 프로젝트

이 프로젝트는 간단한 2D 던전 탐험 게임을 구현한 예제입니다. 플레이어 캐릭터를 조작하여 던전을 탐험하고, 적과 전투를 벌이는 간단한 게임 로직을 포함하고 있습니다.

## ✨ 주요 기능

- 플레이어 이동 및 조작
- 적 AI 및 이동
- 카메라 추적
- 오브젝트 풀링을 이용한 적 생성 및 관리
- 게임 모드 관리

## 🚀 설치 및 실행 방법

1. 이 저장소를 클론합니다.
2. Unity Hub에서 프로젝트를 엽니다.
3. 게임 씬을 열고 실행합니다.

## 📂 프로젝트 구조

```
.
├── Scripts                // 게임 로직 스크립트
│   ├── 🎮 게임 로직
│   │   ├── CharacterBase.cs
│   │   ├── DungeonGameMode.cs
│   │   ├── EnemyBase.cs
│   │   ├── GameMode.cs
│   │   ├── GameManager.cs
│   │   ├── PlayerController.cs
│   │   └── Spawner.cs
│   ├── 🎯 입력 처리
│   │   └── PlayerController.cs
│   ├── 🎬 카메라
│   │   └── SetCameraTarget.cs
│   ├── 🏭 오브젝트 풀
│   │   └── PoolManager.cs
│   ├── 🔄 위치 재조정
│   │   └── Reposition.cs
│   └── 🎨 시각적 요소
│       └── SpriteController.cs
└── ...
```

## 📊 클래스 관계도

```mermaid
classDiagram
    ["GameManager"] --> [GameMode] : 관리
    [GameMode] --> ["PlayerController"] : 제어
    [GameMode] --> [CharacterBase] : 생성
    ["PlayerController"] --> [CharacterBase] : 제어
    [CharacterBase] --> ["SpriteController"] : 사용
    [EnemyBase] --> ["SpriteController"] : 사용
    [Spawner] --> ["PoolManager"] : 사용
    ["SetCameraTarget"] --> ["PlayerController"] : 추적
```

<details>
<summary>🎮 게임 로직</summary>

### CharacterBase

**설명:** 모든 캐릭터의 기본 클래스로, 이동 로직을 포함합니다.

### DungeonGameMode

**설명:** 던전 게임 모드를 관리하는 클래스입니다.

### EnemyBase

**설명:** 적 캐릭터의 기본 클래스로, 이동 및 플레이어 추적 로직을 포함합니다.

### GameMode

**설명:** 게임 모드의 기본 클래스로, 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.

### GameManager

**설명:** 게임의 전역 상태를 관리하는 싱글톤 매니저입니다.

### PlayerController

**설명:** 플레이어의 입력을 받아 캐릭터를 제어합니다.

### Spawner

**설명:** 적 캐릭터를 생성하고 관리합니다.

</details>

<details>
<summary>🎯 입력 처리</summary>

### PlayerController

**설명:** 플레이어의 입력을 받아 캐릭터를 제어합니다. `OnMove` 함수를 통해 이동 입력을 처리합니다.

</details>

<details>
<summary>🎬 카메라</summary>

### SetCameraTarget

**설명:** Cinemachine 카메라의 타겟을 플레이어 캐릭터로 설정하여 카메라가 플레이어를 추적하도록 합니다.

</details>

<details>
<summary>🏭 오브젝트 풀</summary>

### PoolManager

**설명:** 오브젝트 풀링을 관리하여 게임 성능을 향상시킵니다. `Get` 함수를 통해 오브젝트를 재활용하거나 새로 생성합니다.

</details>

<details>
<summary>🔄 위치 재조정</summary>

### Reposition

**설명:** 특정 트리거 영역을 벗어난 오브젝트의 위치를 재조정합니다.

</details>

<details>
<summary>🎨 시각적 요소</summary>

### SpriteController

**설명:** 캐릭터의 애니메이션 및 스프라이트 방향을 업데이트합니다.

</details>


## 🤝 기여 방법

이 프로젝트는 오픈 소스이며 기여를 환영합니다. 버그 수정, 기능 추가, 문서 개선 등 어떤 형태의 기여든 환영합니다.

## 📜 라이선스

이 프로젝트는 MIT 라이선스를 따릅니다. 자세한 내용은 LICENSE 파일을 참조하세요.
