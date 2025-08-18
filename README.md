# 던전 탐험 게임 프로젝트

이 프로젝트는 2D 던전 탐험 게임의 기본적인 기능을 구현한 프로젝트입니다. 플레이어 캐릭터를 조작하여 던전을 탐험하고, 적과 전투를 벌이는 간단한 게임 로직을 포함하고 있습니다.

## 📁 프로젝트 구조

- **Scripts**: 게임 로직, 캐릭터 제어, UI 등 게임의 핵심 스크립트들이 포함되어 있습니다.
- **Prefabs**: 게임 오브젝트 프리팹들이 저장되어 있습니다.
- **Art**: 게임에 사용되는 그래픽 리소스들이 저장되어 있습니다.


## 🎮 게임 로직

<details>
<summary>🎮 GameManager</summary>

    **역할**: 게임의 전반적인 상태와 로직을 관리하는 싱글톤 매니저입니다. 현재 게임 모드를 관리하고 다른 시스템에서 접근할 수 있도록 합니다.

    **핵심 함수**:
    - `GetGameMode()`: 현재 게임 모드를 반환합니다.
    - `SetGameMode()`: 게임 모드를 설정합니다.

</details>

<details>
<summary>🎮 GameMode</summary>

    **역할**: 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.

    **핵심 함수**:
    - `SpawnPlayer()`: 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.

</details>

<details>
<summary>🎮 DungeonGameMode</summary>

    **역할**: 던전 게임 모드를 관리하는 클래스입니다. GameMode를 상속받아 던전 특화 기능을 제공합니다. (현재 구체적인 기능은 명시되지 않았습니다.)

</details>



## 👤 캐릭터

<details>
<summary>🚶 CharacterBase</summary>

    **역할**: 이동 입력을 받아 처리하는 기본 캐릭터 클래스입니다.

    **핵심 함수**:
    - `OnMove()`: 이동 입력을 받아 처리하는 가상 메서드입니다.
    - `HandleMovement()`: 실제 이동 로직을 처리합니다.

</details>

<details>
<summary>😈 EnemyBase</summary>

    **역할**: 적의 이동 로직을 처리합니다. CharacterBase를 상속받습니다.

    **핵심 함수**:
    - `Movement()`: 적의 이동 로직을 처리합니다.
    - `FindTarget()`: 플레이어 타겟을 찾아 이동 방향을 설정합니다.

</details>



## 🎯 입력 처리

<details>
<summary>🕹 PlayerController</summary>

    **역할**: 이동 입력을 받아 캐릭터에 전달합니다.

    **핵심 함수**:
    - `OnMove()`: 이동 입력을 받아 캐릭터에 전달합니다.

</details>



## 🌎 환경

<details>
<summary>📍 Reposition</summary>

    **역할**: 트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다. (예: 맵 경계를 넘어갔을 때 반대편으로 이동)

    **핵심 함수**:
    - `OnTriggerExit2D()`: 트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.

</details>

<details>
<summary>👾 Spawner</summary>

    **역할**:  랜덤한 위치에 적을 생성합니다.

    **핵심 함수**:
    - `SetPlayer()`: 플레이어를 찾아 스포너의 부모로 설정합니다.
    - `Spawn()`: 랜덤한 위치에 적을 생성합니다.

</details>



## 🔧 유틸리티

<details>
<summary>📦 PoolManager</summary>

    **역할**: 오브젝트 풀링을 관리합니다. 지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다.

    **핵심 함수**:
    - `Get()`: 지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다.

</details>



## 🎨 시각적

<details>
<summary>📷 SetCameraTarget</summary>

    **역할**: Cinemachine 카메라의 타겟을 설정합니다. 플레이어 캐릭터를 카메라의 추적 대상으로 설정합니다.

</details>

<details>
<summary>🖼️ SpriteController</summary>

    **역할**: 애니메이션과 스프라이트 방향을 업데이트합니다.

    **핵심 함수**:
    - `LateUpdate()`: 애니메이션과 스프라이트 방향을 업데이트합니다.

</details>
