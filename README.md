# Ragdoll Shooting

ℹ⚠ ***Important: this is a constantly updated document. For now it may not contain full documentation of project. It's better to see the sources directly.*** ⚠ℹ

# General

Ragdoll Shooting is a 2d side-view game, where player is fighting against bot. Shoot and avoid enemy's bullets and kill the enemy to win. Also there are some bonuses in the game, which are useful.

The purpose of this project is show how things work:
 - building system on varied components
 - fighting (healh and damage) system
 - ragdoll usage
 - 2d gunfire based game

The **core approach** of scripting is using of small, loosely-coupled **components** to create complex logic. These components are responsible for only **specific** things (like health / shooting / jumping). And like a **constructor**, whole behavior (eg. of unit) can be built from these components.

Gameplay:

 ![Gameplay](https://github.com/dcrdro/Ragdoll-Shooting/blob/master/Assets/Documentation~/ragdoll-shooting-gamplay.gif)

*All art created by me*

## Roadmap

- [x] shooting
- [x] jumps
- [x] animation
- [x] fight system (health + damage)
- [x] player controller
- [x] hitbox system
- [x] exlosion & bomb
- [x] healing & medical kit
- [x] shield
- [x] bullets
- [x] UI system
- [x] graphics
- [x] effect system & fighting effects
- [x] bonus spawner
- [x] game management
- [x] ragdoll balance
- [ ] *readme documentation*
- [ ] additional setup
- [ ] bones configs
- [ ] object pool
- [ ] mvp adapting
- [ ] import utilities from Profit package

# Overview

## Structure

Game scene hierarchy structure is splitted into 3 global sections:
 - UI
 - World
 - Management
 
 Here is a screenshot:
 
  ![](https://github.com/dcrdro/Ragdoll-Shooting/blob/master/Assets/Documentation~/scene-hierarchy.png)

 ## UI
 Inner structure:
  - UI Camera
  - Panels
     - Game Panel - that is showing during the game
     - Pause Panel - that is showing in pause
     - Game Over Panel - that is showing after player wins / loses
     
 ### UIManager
 It is responsible for checking game state and showing panels depending on it

 Panels may have their own script on them (**PausePanelUI**, **GameOverPanelUI**), to update inner state.
 
 ## World
 
 In this hierarchy world objects are placed - units; environment; holders for spawnable objects.
 
 Unit prefab has 2 variants - player and enemy. They both has many behavior **components attached** to them (according approach as stated before), which are defining the **unit behavior**. Below are the main ones.
 
 The components look like this:
 
   ![](https://github.com/dcrdro/Ragdoll-Shooting/blob/master/Assets/Documentation~/fighter-components.png)
 
 ### Physics Switcher
 It is responsible for switching unit's state - *solid* or *ragdoll*. In solid state unit is staying, can jump and shoot. If unit dies - ragdoll state is enabling.
 
 // ragdoll body
 // solid body
 
 ### Weaponer
 It allows fighter to shoot. It's referencing on **Weapon** base component, that make *abstract* shoot.
 
 ### Jumper
 Component that allows fighter to jump. Here you can define max jumps count and jump speed
 
 ### Health
 Base component for fight system. It implements **IDamagable** and **IHealable** interfaces
 
 ### IDamagable
 Allows to receive damage
 
 ### IHealable
 Allows to apply heal
 
 ### Fighter Identifier
 Contains **ID** of fighter (left or right) which allow to apply different settings 
 
 ### Fighter Controller Base
 Component which is base for fighter controlling. Composing of **Weaponer** and **Jumper** components.
 
 ### Player Keyboard Controller
 Inherits from FighterControllerBase. This component that responsible for controlling the fighter via keyboard. It's attached to **Player** prefab
 
 ### Bot Controller
 Inherits from FighterControllerBase. This omponent that responsible for AI of bot. It's attached to **Enemy** prefab
 
 ## Hitbox system
 
 The skeleton of each fighter consists of several bones. They are body, legs, and so on. Each of these bones has its own parameter, which is affected on it behavior. Beside of unity-special components, it containt **Hit Receiver** component
 
 ### Hit Receiver
 This component has **HitboxID**, and takes outer *damage* and *force*. If fact, it is just *Adapter* for damage, which throws events about it further. They are cathed by several handlers: **DamageHandler**, **ForceHandler**, **HitEffector**
 
 ### DamageHandler
 Actually applies damage to health, calculating it based on **hitbox settings**
 
 ### ForceHandler
 The same as DamageHandler, but for force
 
 ## Effects system
 
 Actions during the game generate some effects: i.e. when bullet hit enemy, the blood particles appears, and the hit sound is playing. This is managed by **effects**
 
 ### IEffect<TArgs>
 Base class for any effect. Contains single method `void Play(T args)`. I.e deriving effects: **ParticlesEffect**, **SoundEffect**
 
 ### EffectArgs
 Args for effect. I.e. position of particles effect
 
 ### Effector Base
 Behavior that is playing the effects. Inheritor classes should only determine *when* they need to use effects
 
 ## Management
 
 ### Bonuses Spawner
 Spawn bonuses in some *point* with some *interval*. It is uses **BonusesFactory** to create bonuses isntances.
 
 ### Factory
 Created *product* by *id*. 
 
 ### Game Over Manager
 Checking both fighters' health, and listening them on Dead event. If it happens, event about *game over* is sent. Then, **UIManager** or other **handlers** can handle it
 
 ### App Manager
 General manager, that is repsonsible for *pause/unpause* game, and *restart* it.
 
 ## Editor using
 
 There is a custom editor for **mapping** settings. It is used in **Hitbox mapping** and **Fighter mapping**. It allows easy to setup *config* based on *ID*.
