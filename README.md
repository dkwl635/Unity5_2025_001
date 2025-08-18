# 🎮 던전 탐험 게임 프로젝트

이 프로젝트는 유니티 엔진으로 개발된 던전 탐험 게임의 기본 프레임워크를 제공합니다. 플레이어 캐릭터 조작, 적 AI, 게임 상태 관리, 카메라 시스템, 오브젝트 풀링 등 핵심 기능들을 구현하고 있습니다.

<details>
<summary><b>🕹️ 플레이어 & 입력</b></summary>

<details>
<summary><b>🎮 <code>PlayerController</code></b></summary>

**설명**: 이동 입력을 받아 캐릭터에 전달하는 역할을 합니다.

**주요 함수**:
- `GetCharacter()`: 연결된 캐릭터 객체를 반환합니다.
- `SetCharacter()`: 캐릭터 객체를 설정합니다.
- `OnMove()`: 이동 입력을 받아 캐릭터의 `OnMove()` 함수를 호출합니다.

```C#
// PlayerController.cs 예시
public void OnMove(Vector2 direction) {
    _character.OnMove(direction);
}
```

</details>

<details>
<summary><b>🧍 <code>CharacterBase</code></b></summary>

**설명**: 이동 입력을 받아 처리하는 기본 캐릭터 클래스입니다.  `OnMove` 함수는 자식 클래스에서 오버라이드하여 다양한 이동 로직을 구현할 수 있도록 설계되었습니다.

**주요 함수**:
- `GetPlayerController()`: 연결된 플레이어 컨트롤러 객체를 반환합니다.
- `SetPlayerController()`: 플레이어 컨트롤러 객체를 설정합니다.
- `OnMove(Vector2 direction)`: 이동 입력을 받아 처리하는 가상 함수입니다.
- `HandleMovement()`: 실제 이동 로직을 처리합니다.  자식 클래스에서 오버라이드 가능합니다.

```C#
// CharacterBase.cs 예시
public virtual void OnMove(Vector2 direction) {
    // 이동 로직 구현 (자식 클래스에서 오버라이드)
    HandleMovement(direction);
}
```

</details>

</details>

<details>
<summary><b>👾 적 AI</b></summary>

<details>
<summary><b>😈 <code>EnemyBase</code></b></summary>

**설명**: 적의 이동 로직을 처리하는 기본 클래스입니다.

**주요 함수**:
- `Movement()`: 적의 이동 로직을 처리합니다.
- `FindTarget()`: 플레이어 타겟을 찾아 이동 방향을 설정합니다.
- `OnMove(Vector2 direction)`: 이동 입력을 받아 처리하는 가상 함수입니다. (CharacterBase 상속)


</details>

<details>
<summary><b>🐾 <code>Spawner</code></b></summary>

**설명**: 랜덤한 위치에 적을 생성합니다.  플레이어를 찾아 스포너의 부모로 설정하여 플레이어를 따라다니도록 합니다.

**주요 함수**:
- `SetPlayer()`: 플레이어를 찾아 스포너의 부모로 설정합니다.
- `Spawn()`: 랜덤한 위치에 적을 생성합니다.

</details>

</details>

<details>
<summary><b>🌍 게임 관리</b></summary>

<details>
<summary><b>🏰 <code>GameManager</code></b></summary>

**설명**: 게임의 전역 상태를 관리하는 싱글톤 매니저입니다. 현재 게임 모드를 관리하고 다른 시스템에서 접근할 수 있도록 합니다.

**주요 함수**:
- `GetGameMode()`: 현재 게임 모드를 반환합니다.
- `SetGameMode()`: 게임 모드를 설정합니다.

</details>

<details>
<summary><b>🚩 <code>GameMode</code></b></summary>

**설명**: 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다. 게임 모드의 기본 기능을 제공합니다.

**주요 함수**:
- `GetPlayerController()`: 플레이어 컨트롤러를 반환합니다.
- `GetCharacter()`: 플레이어 캐릭터를 반환합니다.
- `SpawnPlayer()`: 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.

</details>

<details>
<summary><b>🏯 <code>DungeonGameMode</code></b></summary>

**설명**: 던전 게임 모드를 관리하는 클래스입니다. `GameMode`를 상속받아 던전 특화 기능을 제공합니다. (추가적인 함수 설명 필요)

</details>

</details>


<details>
<summary><b>🛠️ 유틸리티</b></summary>

<details>
<summary><b>📦 <code>PoolManager</code></b></summary>

**설명**: 오브젝트 풀링을 관리하는 클래스입니다. 지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다.

**주요 함수**:
- `Get(int index)`: 지정된 인덱스의 비활성화된 오브젝트를 반환하거나, 없으면 새로 생성합니다.

</details>

<details>
<summary><b>➡️ <code>Reposition</code></b></summary>

**설명**: 트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.

**주요 함수**:
- `OnTriggerExit2D()`: 트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.

</details>

<details>
<summary><b>🎥 <code>SetCameraTarget</code></b></summary>

**설명**: Cinemachine 카메라의 타겟을 설정하는 클래스입니다. 플레이어 캐릭터를 카메라의 추적 대상으로 설정합니다.

</details>

<details>
<summary><b>💅 <code>SpriteController</code></b></summary>

**설명**: 애니메이션과 스프라이트 방향을 업데이트합니다.

**주요 함수**:
- `LateUpdate()`: 애니메이션과 스프라이트 방향을 업데이트합니다.

</details>

</details>
