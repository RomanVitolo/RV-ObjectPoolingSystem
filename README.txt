RV-ObjectPoolingSystem Package

The RV-ObjectPoolingSystem is a Unity package designed to efficiently manage the reuse of game objects, reducing performance overhead associated with frequent instantiation and destruction.

Installation

To include this package in your Unity project:

1. Ensure Git is Installed
Unity requires Git to fetch packages from GitHub.
- Download and install Git from the [official website](https://git-scm.com/downloads).
- After installation, restart your computer to ensure Unity recognizes Git.

2. Add the Package via Unity Package Manager
- Open Unity and navigate to Window > Package Manager.
- Click the + button and select Add package from git URL....
- Enter the following URL: https://github.com/RomanVitolo/RV-ObjectPoolingSystem.git#upm
- Click Add.

For detailed instructions, refer to the [Unity Manual on installing packages from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html).

Usage:
After installation, you can utilize the object pooling system by inheriting from the BaseObjectPool<T> class. This allows for the creation of specific object pools tailored to your game's requirements.

Example: Creating a Projectile Pool GameObject

1. Define the Pooled Object
Create a Projectile class that inherits from MonoBehaviour.
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Projectile-specific code here
}


2. Create the Object Pool
Create a ProjectilePool class that inherits from BaseObjectPool<Projectile>.

using RV.PoolingSystem.Runtime;
using UnityEngine;

public class ProjectilePool : BaseObjectPool<Projectile>
{
    // Additional pool-specific code here
}


3. Using the Pool
To retrieve an object from the pool:

Projectile projectile = projectilePool.GetObject();

To return an object to the pool:

projectilePool.ReturnObject(projectile);

By integrating this system, you can enhance your game's performance through efficient object reuse.

License
This project is licensed under the MIT License.

Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue for suggestions or bug fixes.

Contact
For any inquiries, reach out via [https://romanvitolo.com] or open an issue on GitHub.

