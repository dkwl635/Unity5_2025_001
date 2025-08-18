# C++ 프로젝트 README

이 프로젝트는 게임 개발에 사용될 수 있는 다양한 기능을 제공하는 C++ 클래스들을 포함하고 있습니다. 캐릭터 제어, 게임 모드 관리, 오브젝트 풀링, 스프라이트 제어 등 다양한 기능을 모듈화하여 재사용성을 높였습니다.

## 주요 클래스 설명

### `CharacterBase`

캐릭터의 기본 기능을 제공하는 추상 클래스입니다. 플레이어 캐릭터와 적 캐릭터 모두 이 클래스를 상속받아 사용하며, 이동, 플레이어 컨트롤러 설정 등의 공통 기능을 제공합니다.

```cpp
class CharacterBase {
  // ...
};
```

**주요 함수:**

* `GetPlayerController()`: 캐릭터의 플레이어 컨트롤러를 반환합니다.
* `SetPlayerController()`: 캐릭터의 플레이어 컨트롤러를 설정합니다.
* `OnMove()`: 캐릭터 이동 시 호출되는 함수입니다.
* `Awake()`: 초기화 작업을 수행합니다. Unity의 Awake 함수와 유사합니다.
* `Start()`: 게임 시작 시 호출되는 함수입니다. Unity의 Start 함수와 유사합니다.
* `FixedUpdate()`: 고정된 시간 간격으로 호출되는 함수입니다. Unity의 FixedUpdate 함수와 유사합니다.
* `HandleMovement()`: 캐릭터의 이동 로직을 처리합니다.


### `DungeonGameMode`

던전 게임 모드를 관리하는 클래스입니다. (자세한 설명 부재)

### `EnemyBase`

적 캐릭터의 기본 기능을 제공하는 클래스입니다. `CharacterBase` 클래스를 상속받아 구현됩니다.

```cpp
class EnemyBase : public CharacterBase {
  // ...
};
```

**주요 함수:**

* `Awake()`, `Start()`, `FixedUpdate()`:  `CharacterBase`와 동일한 역할을 합니다.
* `Movement()`: 적 캐릭터의 이동 로직을 처리합니다.
* `OnEnable()`: 오브젝트가 활성화될 때 호출됩니다. Unity의 OnEnable 함수와 유사합니다.
* `FindTarget()`: 공격 대상을 찾는 함수입니다.
* `OnMove()`:  `CharacterBase`와 동일한 역할을 합니다.


### `GameManager`

게임 전반을 관리하는 클래스입니다.

**주요 함수:**

* `GetGameMode()`: 현재 게임 모드를 반환합니다.
* `SetGameMode()`: 게임 모드를 설정합니다.
* `Awake()`: 초기화 작업을 수행합니다.


### `GameMode`

게임 모드의 기본 기능을 제공하는 클래스입니다.

**주요 함수:**

* `GetPlayerController()`: 플레이어 컨트롤러를 반환합니다.
* `GetCharacter()`: 캐릭터를 반환합니다.
* `Start()`: 게임 시작 시 호출되는 함수입니다.
* `SpawnPlayer()`: 플레이어를 생성합니다.


### `PlayerController`

플레이어 캐릭터를 제어하는 클래스입니다.

**주요 함수:**

* `GetCharacter()`: 제어하는 캐릭터를 반환합니다.
* `SetCharacter()`: 제어할 캐릭터를 설정합니다.
* `OnMove()`: 캐릭터 이동 시 호출되는 함수입니다.


### `PoolManager`

오브젝트 풀링을 관리하는 클래스입니다. 게임 오브젝트를 재활용하여 성능을 향상시킵니다.

**주요 함수:**

* `Awake()`: 초기화 작업을 수행합니다.
* `Get()`: 풀에서 오브젝트를 가져옵니다.


### `Reposition`

오브젝트의 위치를 재설정하는 클래스입니다.

**주요 함수:**

* `Awake()`: 초기화 작업을 수행합니다.
* `OnTriggerExit2D()`: 2D 트리거 영역을 벗어날 때 호출됩니다. Unity의 OnTriggerEnter2D 함수와 유사합니다.


### `SetCameraTarget`

카메라의 타겟을 설정하는 클래스입니다.

**주요 함수:**

* `FixedUpdate()`: 고정된 시간 간격으로 호출되는 함수입니다.


### `Spawner`

오브젝트를 생성하는 클래스입니다.

**주요 함수:**

* `Awake()`, `Start()`, `Update()`: Unity의 해당 함수들과 유사한 역할을 합니다.
* `SetPlayer()`: 플레이어를 설정합니다.
* `Spawn()`: 오브젝트를 생성합니다.


### `SpriteController`

스프라이트를 제어하는 클래스입니다.

**주요 함수:**

* `Awake()`, `Start()`, `Update()`, `LateUpdate()`: Unity의 해당 함수들과 유사한 역할을 합니다.


## 나머지 클래스들

`SetCameraTarget.cs`, `CharacterBase.cs`, `EnemyBase.cs`, `SpriteController.cs`, `DungeonGameMode.cs`, `Spawner.cs`, `GameManager.cs`, `GameMode.cs`, `PoolManager.cs`, `PlayerController.cs`, `Reposition.cs` 클래스들은 위에서 설명한 클래스들과 동일한 이름을 가진 C# 스크립트 파일로 추정되며,  README에 제공된 정보가 부족하여 자세한 설명을 추가할 수 없습니다.  추후 정보가 제공되면 업데이트하겠습니다.


## 향후 개발 계획

* 각 클래스에 대한 상세한 문서 추가
* 예제 코드 추가
* 성능 최적화


이 README 파일은 프로젝트의 기본적인 구조와 주요 클래스에 대한 정보를 제공합니다.  더 자세한 내용은 코드 주석을 참고해주세요.  궁금한 점이나 제안 사항이 있으면 언제든지 이슈를 남겨주세요.
