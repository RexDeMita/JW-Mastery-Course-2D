using UnityEngine;

namespace Lesson_Notes
{
    public class L5LowerFrameRate: MonoBehaviour
    {
        /*
    triggers vs colliders: colliders are a physical impediment and have code, triggers just fire off code
    
    make sure colliders/triggers of objects like checkpoints dont have unwanted effects to raycasts or objects
    
    use layers to organize collider interactions
    
    FixedUpdate vs Update
        fixed update is for code that is not affected by frame rate: horizontal axis is held down every frame you want the player to move horizontally
        update is for code dependent on a specific frame and thus the frame rate: input using GetButtonDown could be called a varying number of times based on the frame rate if it is inside of fixed update
            update will keep the number of inputs allowed the same because the input is based on frame rate
    
    change the frame rate of the project to see if any bugs show up at lower frame rates
        System.Threading.Thread.Sleep(number of milliseconds between frames)
        
    */
    }
}
