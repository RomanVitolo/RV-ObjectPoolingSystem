# RomanVitolo-R-V-ObjectPoolingSystem

# Unity Object Pooling System

## Overview
The Unity Object Pooling System is a reusable package designed to efficiently manage the instantiation and reuse of game objects, particularly for objects frequently created and destroyed, such as projectiles. By reusing inactive objects, this system reduces performance overhead caused by frequent instantiations and destructions.

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/RomanVitolo/RV-ObjectPoolingSystem.git
   ```
2. Open the project in Unity.
3. Add the necessary scripts to your project.

## Package Components
### 1. **ObjectPool<T>**
A generic class responsible for managing object pooling.

#### **Fields**
- `componentType` *(T)*: The type of component to be pooled.
- `objects` *(Queue<T>)*: A queue storing inactive objects.
- `parentTransform` *(Transform)*: The transform under which all pooled objects are parented.

#### **Constructor**
```csharp
ObjectPool(T componentType, int initialSize, Transform parent)
```
- Instantiates an initial pool of objects and deactivates them.

#### **Methods**
- `Get() -> T`:
  - Retrieves an object from the pool.
  - If none are available, creates a new one.
  
- `ReturnToPool(T obj)`:
  - Deactivates and returns an object to the pool.

---

### 2. **BaseObjectPool<T>**
An abstract base class that integrates object pooling with Unity's `MonoBehaviour`.

#### **Serialized Fields**
- `_poolName` *(string)*: The name of the object pool.
- `_objectType` *(T)*: The type of object being pooled.
- `_initialPoolSize` *(int)*: Initial number of objects in the pool.
- `_objectParent` *(Transform)*: The parent transform for pooled objects.

#### **Methods**
- `GetObject() -> T`:
  - Retrieves an object from the pool.
  
- `ReturnObject(T objectToReturn)`:
  - Returns an object back to the pool.
  
#### **Virtual Methods**
- `Awake()`:
  - Initializes the object pool during the Unity lifecycle.

---

### 3. **Projectile**
A class representing a pooled projectile.

#### **Serialized Fields**
- `_damage` *(int)*: The damage value inflicted by the projectile.

#### **Methods**
- `OnEnable()`:
  - Ensures the projectile pool reference is initialized.

- `OnTriggerEnter(Collider other)`:
  - Checks if the collided object implements `ITarget`.
  - If it does, applies damage and returns the projectile to the pool.

---

## Sample Usage: Projectile Pooling
A specialized implementation demonstrating how to use the Object Pooling pattern for managing projectile instances.

#### **Overrides**
- `Awake()`:
  - Initializes the projectile pool.
  
- `ReturnObject(Projectile obj)`:
  - Calls the base implementation to return projectiles to the pool.

#### **Using the Sample**
To implement this package in a Unity project:
1. **Create a pool:**
   ```csharp
   ProjectilePool projectilePool = new ProjectilePool();
   ```
2. **Get an object from the pool:**
   ```csharp
   Projectile projectile = projectilePool.GetObject();
   ```
3. **Return an object to the pool:**
   ```csharp
   projectilePool.ReturnObject(projectile);
   ```

This package ensures efficient memory management and performance optimization by reusing objects rather than constantly instantiating and destroying them.

## License
This project is licensed under the MIT License.

## Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue for suggestions or bug fixes.

## Contact
For any inquiries, reach out via [(https://romanvitolo.com] or open an issue on GitHub.

