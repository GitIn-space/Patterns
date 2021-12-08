<Not writing personal information in a public repo, check Canvas for it>

A prototype survival/city builder/Factorio-esque/something simulator. Gather resources and build stuff, navigate the world with QWEASD and the building menu with ZXCV

Patterns:
Singleton - Uimanager, Factorymanager, Resourcemanager: "Global" access to classes dedicated to managing UI and unit production, more than one of these would potentially lead to clutter or spaghetti when creating units or resources.
Observer - Factorymanager <-> Factory: Newly created Factories register themselves as available to the Factorymanager, which when appropriate activates them to produce new units.
Factory - Factory, Resourcemanager: Is given a prefab when activated to create after a certain time has passed, it doesn't matter to it what it's given as long as it's derived from something that specific factory can handle.
Builder - Goldbuilder/Goldfabricator: Lets you change the parameters of a gold mine while making it, if left unchanged they'll use defaults given in the inspector
Mediator - Factorymanager: Used to communicate with Factories without screwing with their own internal logic.
Dependency injection - Just about all classes derived from MonoBehaviour: This might be a reach, so feel free to correct this if it's wrong. I read somewhere that the argument could be made that whenever you drag something via the inspector it could be interpreted as dependency injection, since it's a dependency that you inject.
State machine - Menu: I'll make an argument that it's there but abstracted. The different canvas elements making up the ZXCV menu has the functionality of a FSM if not traditionally implemented.