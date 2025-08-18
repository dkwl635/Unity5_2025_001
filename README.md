# 🎮 던전 탐험 게임 프로젝트

이 프로젝트는 유니티 엔진을 사용하여 개발된 간단한 던전 탐험 게임입니다. 플레이어는 캐릭터를 조작하여 던전을 탐험하고, 적과 전투를 벌입니다. 게임의 핵심 기능은 다음과 같습니다:

- **캐릭터 이동 및 조작**: 플레이어는 입력을 통해 캐릭터를 이동하고 상호작용할 수 있습니다.
- **적 AI**: 적들은 플레이어를 추적하고 공격합니다.
- **카메라 시스템**: 카메라는 플레이어를 따라다니며 게임 화면을 보여줍니다.
- **오브젝트 풀링**: 오브젝트 풀링을 사용하여 게임 성능을 최적화합니다.
- **게임 모드 관리**: 다양한 게임 모드를 지원합니다.


## 📂 프로젝트 구조

```
- Scripts/
  - Character/
    - CharacterBase.cs
    - EnemyBase.cs
    - PlayerController.cs
  - GameManagement/
    - DungeonGameMode.cs
    - GameManager.cs
    - GameMode.cs
  - Utility/
    - PoolManager.cs
    - Reposition.cs
    - SetCameraTarget.cs
    - Spawner.cs
    - SpriteController.cs
```

- `Scripts/Character`: 캐릭터 관련 스크립트들이 위치합니다.
- `Scripts/GameManagement`: 게임 관리 관련 스크립트들이 위치합니다.
- `Scripts/Utility`: 유틸리티 스크립트들이 위치합니다.


## 🕸️ 클래스 관계도

```mermaid
classDiagram
    "CharacterBase" --> "SpriteController"
    "CharacterBase" --> "PlayerController"
    "EnemyBase" --> "SpriteController"
    "GameManager" --> "GameMode"
    "GameMode" --> "PlayerController"
    "GameMode" --> "CharacterBase"
    "PlayerController" --> "CharacterBase"
    "Spawner" --> "PoolManager"
```


<details>
<summary> 🎮 게임 로직 </summary>

<details>
<summary>🎮 GameManager</summary>

**역할**: 게임의 전역 상태를 관리하는 싱글톤 매니저.
**주요 기능**: 현재 게임 모드 관리, 다른 시스템 접근 제공.

</details>

<details>
<summary>🎮 GameMode</summary>

**역할**: 플레이어 컨트롤러와 캐릭터 생성 및 연결.
**주요 기능**: 플레이어 생성 및 초기화.
**핵심 함수**:
- `SpawnPlayer()`: 플레이어 컨트롤러와 캐릭터를 생성하고 연결.

</details>

<details>
<summary>🎮 DungeonGameMode</summary>

**역할**: 던전 게임 모드 관리. `GameMode` 상속.
**주요 기능**: 던전 특화 기능 제공 (구체적인 기능은 코드 참조).

</details>
</details>

<details>
<summary> 👤 캐릭터 </summary>

<details>
<summary>👤 CharacterBase</summary>

**역할**: 이동 입력 처리.
**주요 기능**: 이동 로직 구현.
**핵심 함수**:
- `OnMove()`: 이동 입력을 받아 처리하는 가상 메서드.
- `HandleMovement()`: 실제 이동 로직 처리.

</details>

<details>
<summary>👤 PlayerController</summary>

**역할**: 이동 입력을 받아 캐릭터에 전달.
**주요 기능**: 사용자 입력 처리 및 캐릭터 제어.
**핵심 함수**:
- `OnMove()`: 이동 입력을 받아 캐릭터에 전달.

</details>

<details>
<summary>👤 EnemyBase</summary>

**역할**: 적의 이동 로직 처리.
**주요 기능**: 적 AI 구현.
**핵심 함수**:
- `Movement()`: 적의 이동 로직 처리.
- `FindTarget()`: 플레이어 타겟을 찾아 이동 방향 설정.

</details>
</details>


<details>
<summary> 🛠️ 유틸리티 </summary>

<details>
<summary>🛠️ PoolManager</summary>

**역할**: 오브젝트 풀링 관리.
**주요 기능**: 오브젝트 재활용 및 생성.
**핵심 함수**:
- `Get()`: 지정된 인덱스의 비활성화된 오브젝트 반환 또는 새로 생성.

</details>

<details>
<summary>🛠️ Reposition</summary>

**역할**: 오브젝트 위치 재조정.
**주요 기능**: 트리거 영역 벗어날 때 위치 조정.
**핵심 함수**:
- `OnTriggerExit2D()`: 트리거 영역을 벗어날 때 오브젝트 위치 재조정.

</details>

<details>
<summary>🛠️ SetCameraTarget</summary>

**역할**: 카메라 타겟 설정.
**주요 기능**: 플레이어 캐릭터를 카메라 추적 대상으로 설정.

</details>

<details>
<summary>🛠️ Spawner</summary>

**역할**: 적 생성.
**주요 기능**: 랜덤 위치에 적 생성.
**핵심 함수**:
- `SetPlayer()`: 플레이어를 찾아 스포너의 부모로 설정.
- `Spawn()`: 랜덤한 위치에 적 생성.

</details>

<details>
<summary>🛠️ SpriteController</summary>

**역할**: 애니메이션 및 스프라이트 방향 업데이트.
**주요 기능**: 캐릭터 시각적 요소 제어.
**핵심 함수**:
- `LateUpdate()`: 애니메이션과 스프라이트 방향 업데이트.

</details>
</details>



## 📜 라이선스

MIT License. 자세한 내용은 LICENSE 파일을 참조하세요.
