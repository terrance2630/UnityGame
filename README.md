[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-f059dc9a6f8d3a56e377f745f24479a46679e63a5d9fe6f495e02850cd0d8118.svg)](https://classroom.github.com/online_ide?assignment_repo_id=445409&assignment_repo_type=GroupAssignmentRepo)


**The University of Melbourne**
# COMP30019 – Graphics and Interaction

Final Electronic Submission (project): **4pm, November 1**

Do not forget **One member** of your group must submit a text file to the LMS (Canvas) by the due date which includes the commit ID of your final submission.

You can add a link to your Gameplay Video here but you must have already submit it by **4pm, October 17**

# Project-2 README

You must modify this `README.md` that describes your application, specifically what it does, how to use it, and how you evaluated and improved it.

Remember that _"this document"_ should be `well written` and formatted **appropriately**. This is just an example of different formating tools available for you. For help with the format you can find a guide [here](https://docs.github.com/en/github/writing-on-github).


**Get ready to complete all the tasks:**

- [x] Read the handout for Project-2 carefully.

- [x] Brief explanation of the game.

- [x] How to use it (especially the user interface aspects).

- [x] How you designed objects and entities.

- [x] How you handled the graphics pipeline and camera motion.

- [x] The procedural generation technique and/or algorithm used, including a high level description of the implementation details.

- [x] Descriptions of how the custom shaders work (and which two should be marked).

- [x] A description of the particle system you wish to be marked and how to locate it in your Unity project.

- [x] Description of the querying and observational methods used, including a description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

- [x] Document the changes made to your game based on the information collected during the evaluation.

- [x] References and external resources that you used.

- [x] A description of the contributions made by each member of the group.

## Table of contents
* [Team Members](#team-members)
* [Explanation of the game](#explanation-of-the-game)
* [Technologies](#technologies)
* [Using Images](#using-images)
* [Code Snipets ](#code-snippets)

## Team Members

| Name | Task | State |
| :---         |     :---:      |          ---: |
| Tianqi Wang  | Environment Setup, Winning Logic, Procedural Generation     |  Done |
| Jiaqi Tang   | Shader, UI, Scene tranfering      |  Done |
| Zhilu Ye    | Video Designing, UI, Particle System      |  Done |
| Junran Lin  | Player moving, Enemy moving, Defeating Logic |  Done |

## Explanation of the game
Our game is a first person shooter (FPS) that....

You can use emojis :+1: but do not over use it, we are looking for professional work. If you would not add them in your job, do not use them here! :shipit:

	
## Technologies
Project is created with:
* Unity 2021.1.13f1
* Ipsum version: 2.33
* Ament library version: 999

1. Game Explanation

Escape is a combination of survival horror and first-person shooter games produced by the MI18 video game workshop. The main character agent 18 was on the investigation of a factory for illegal biochemistry experiments and was attacked accidentally. He woke up and found himself in this deserted factory with a group of zombies. The aim for the player is to assist agent 18 to find all three keys in order to open the exit. Notice: When we organize unnecessary files in the game, we delete the function which is to quit the game under the mode of Unity editor. We default that our player will not open the game through the Unity editor.

2. User Guide

Start menu: Players can choose to start, quit or customize the settings of the game on this page. If the player chooses to start the game, a detailed introduction on game operation and goal of this game will pop up to guide the player. In the settings section, players can adjust volume and mouse sensitivity.

Game Play: Player has 100 hp. The player is born at the front door of the factory and facing inside. Players are borned at the front door of this factory with full health(100 hp), players use WASD to move and use mouse to change the view. Players can attack zombies by pressing. Several monsters wander around each floor of the factory. When a player appears in the monster's sight, it will rush towards the player and attack the player at speed 1hp/sec. Players can choose to pause in the middle of the game, where they can either start over or exit the game. After a certain time, there will be amount of ghost popping up if the player has not failed or succeeded. The player will get damaged when passing through the ghosts.

Game Ending:  When the player’s hp is down to 0, the game automatically ends with “DEAD” page showing. If the player successfully collects three keys and makes it to the exit, “I SURVIVED” page is shown implying the character successfully escapes.

3. Design of objects and entities

Elements are designed to enhance the scary atmosphere of the game. We designed the maze to look like an old factory according to the background story. The building consists of four floors connected by steel stairs. The construction includes shelves and boxes to not only make the scene more realistic but also act as hints to guide the players to find the right way to keys. The structure of the maze has been constantly polished in order to adjust the difficulty of the game to be more entertaining.

Since this game is in first person, we focus on the design of the enemy character. We designed two different types of enemy characters: ghost and ghoul. Those two types of monster can both cause damage to the player. And ghosts only appear after a certain amount of time which makes it more scary because the player now has to be conscious of the time. Also the amount of ghosts increases over time which does not only enhance the tension but also avoid the situation where the game never ends.  Ghoul is black monster with different movements depending on its status, it rushes after seeing the player. There is also a special gesture for attacking, along with blood effects we generated. Scary background music is played along the game, we also added puffing sound in response to pipelines in the factory model to make it more realistic. 

4. Graphic pipeline and camera motion

We tried to use URP(universal render pipeline) assets and found this will conflict with standard pipeline and caused the scene we already developed to break down. Eventually we choose to use the built-in render pipeline.
Camera is moving with the character, and the camera will change when the mouse changes. Our camera is set at the character’s head, and is in first person view. The reference is written below. The camera will also make the character rotate to the direction where the camera is looking at.            

```c#
// Code for ghost spawn, procedural generation algorithm
void SpawnItem()
    {
        // Get player's position.
        float x = player.position.x;
        float y = player.position.y;
        float z = player.position.z;
        
        // Create a rule for clone's position.
        Vector3 randPosition = new Vector3(Random.Range(x-spawn_distance, x+spawn_distance),
                                            Random.Range(y, y+spawn_distance/2), 
                                            Random.Range(z, z+spawn_distance+2));
        
        //Clone the object with given position.
        GameObject clone = Instantiate(itemToSpread, randPosition, Quaternion.identity);
        clone.tag = "Clone";    
    }

void Update() 
    {
        var clones = GameObject.FindGameObjectsWithTag("Clone");
        
        // Let the ghost disappear.
        foreach(var clone in clones){
            Destroy(clone, duration_time);
        }

        //Spawn item for every 'spawn_time_gap'.
        if(Time.time > next_spawn_time)
        {
            for (var i = 0; i < numItemToSpawn; i++)
            {
                SpawnItem();
            }
            next_spawn_time += spawn_time_gap;
        }

        // Increase the amount of ghost after certain amount of time
        if(Time.time > next_increase_time)
        {
            numItemToSpawn += extra_per_ten_second;
            next_increase_time += spawn_time_gap*1.5f;
        }        
    }
```
```c#
// Code for Camera motion, camera move with mouse.
public class MouseComponent : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX * 2);

        
    }
}

```

5.Procedural Generation technique and algorithm used

The main body of our procedural generation is a white ghost (Figure 5.1). White ghosts will be randomly generated anywhere around the character, at a random time. As the game time increases, the number of ghosts will increase. They can cause damage to the player, which means that the longer the escape time, the harder it is to pass the level. We chose to apply the procedural generation on a type of ghoul. In order to distinguish, we make the procedural generation objects look like white ghosts. The library random is used to generate the position where the white ghost appears (Figure 5.2). When the player passes through the white ghost area, the player will be damaged, the health volume will be decreased, and it will also be accompanied by special sound effects.

<p align="center">
  <img src="Report Image/procedural.png"  width="300" >
</p>

6. Description of how the custom shaders work (and which to be marked)
There are three shaders used in our design. Only the first two(Cg vertex shader and Celshader) are for marking.
a.Cg vertex shader (designed to be marked)
Source: Game\Assets\Shader\RippleWater.shader

This shader is used on the water surface on the first floor. Ripplewater simulates waves on different wave bands and heights, and looks more like scenes by the seaside. Since the scene of this game is located indoors, we made a few adjustments: 1. Random waves are not used. 2. Decrease the amplitude of the waves. The color of the water comes from the combination of several different colors and textures.. This image shows the resulting scene, since the surface is dynamic it will be more clear in the game.
<p align="center">
  <img src="Report Image/water.png"  width="300" >
</p>

b. Cel Shader (designed to be marked)
Source: Project2 Game\Assets\Shader\CelShader.shader

This shader is used on special attacking effects of ghost and ghoul. The implementation is based on Toon shading, which transfers the performance of 3D Surfaces to simulate 2D flat surfaces, aiming to reduce the horrible effect of massive meat flying out and inform the player of being attacked.   Besides, to make the model of ghosts more attractive as a warning to the player, the Toon shading is also used for ghosts, which will catch the player’s attention in a better way.
The procedure of shading is shown as below:
i)Calculate the amount of light received by the surface from the main directional light by Blinn-Phong shading model.
ii)Divide the lighting into dark and light bands.
iii)Add the effect of ambient light
iv)Soften the edge between dark and light
v)Implement specular reflection that depends on the view.
vi)Implement Rim lighting to simulate reflected light or backlighting 
vii)Add shadow casting.

<p align="center">
  <img src="Report Image/shader1.png"  width="300" >
</p>


c. Phong Shader
Source:Game\Assets\Shader\PhongShader.shader

This shader is used on the trees for better appearance. The original tree was rather rigid, but after using Phong shader, it became agile and full of vitality. This shader is not in the scope of marked.

<p align="center">
  <img src="Report Image/tree.png"  width="300" >
</p>

7.A description of the particle system you wish to be marked and how to locate it in your Unity project.
When the player collides with the ghoul, there will be blood and meat splashing out what our particle system is designed for. This special effect reminds the ghoul of the damage at the moment. 

Location: project2-project2_group_18/Project2 Game/Assets/Models/BloodDecalsAndEffects/BloodGushFX/

<p align="center">
  <img src="Report Image/particle system.png"  width="300" >
</p> 

The sand effect after the game is won and the wind effect at the front of the fan are builded with a particle system.


8.Evaluation and improvements:  Querying techniques

Compared with questionnaires, interviews have more affinity. We can be pre-processed as soon as feedback is received. We can deeply understand the problem and discuss their expectations about modification. We start from four aspects. There are the user interface, the game environment, game rule design and ghoul design. We invited 8 participants and conducted a semi-structured interview. The first half is based on the above four aspects, and the last is an open question. We record interviews by voice recording, so that the interview rhythm will not become procrastinated, and it is convenient for us to review the points. Regarding the user interface settings, some participants reported that they had to read the operation guide and game introduction every time to restart the game, which was too cumbersome. Therefore, we modified the user interface to show the operation and introduction only at the first time the player starts the game. Regarding the game environment, everyone praised the surprises and ingenuity found in the game and was very satisfied with things such as reflective water surface, sand and dust, etc.. The setting for ghools is a bit singular and cannot continue to bring new visual impact. For this, we have designed different types of ghouls, for example, different appearances or different speeds. Lastly, in the open question part, some participants said that shooting elements can be added.Considering that this game is developed around escape and horror elements, if shooting is added, the sense of oppression and tension in the game will be reduced, which will change the nature of the game to an adventure game.

After completing the above adjustments, we invited two more participants to help us with ghost adjustment and box placement. In the process of playing and adjusting the game repeatedly, we found the most suitable box placement location and the number and speed of randomly generated ghosts. According to the player’s escape time and the blood volume in the process, we have made the balance between challenge and boredom.

We invited a total of 10 participants for the evaluation.

9.Evaluation and improvements:  observation method
We apply the observation method to evaluation twice. After the game was roughly completed, we invited four participants to test this game. Because the disadvantage of thinking aloud is that players may be nervous and change their usual behavior which may lead the evaluation results to be distorted, we avoid this way to do observation. Considering that this game has only been played by developers before, there may be situations that require a small amount of background knowledge during the game. Therefore we chose a cooperative evaluation for the first time. In the process of playing, when the player encounters a problem, immediately record and answer them. This allows players to complete the entire evaluation easily and relaxedly.
Participants’ main suggestions are organized as follows:
1)Map is not big enough, too easy to pass.
2)Ghoul will run ahead to the wall instead of chasing the player.
3)The damage caused by ghoul is too low. It means the player can pass without hiding from ghouls.
4)The scenes is too dark, hard to notice the ghost running towards the player
According to the suggestion above, we made the following adjustments and improvements:
1) We redraw the map, changing the original one-level building to three-level building.
2) We fix the bug about the ghoul’s action of keep running toward the wall. They will turn automatically.
3) We increase the damage caused by ghoul.
4) We installed a light source above the character's head to clearly illuminate the front view.
5) We have added a story introduction for the game to demonstrate the condition of passing the level.

After making the following adjustments and optimizations, we conducted a second evaluation. This time we invited four participants with zero background knowledge to experience this game and conduct evaluations. The post-task walkthrough is quite in line with our expectations and assumptions. When the player was playing, we did not provide any help. However,  we record the difficulties encountered by the player at the same time silently, such as being surrounded by ghouls and unable to escape. After the game is over, we ask the players for bugs or difficulties found. We asked the recorded questions to help participants recall their memories. 
They also reflect to us the following problem to improve the game：
1) Always forget how many cards they collected.
2) The Start Menu does not perfectly fit with canvas.
3) Difficult to escape from the damage range of ghouls, So that there will be more and more ghouls around the player after time passes.

In response to the valuable comments received，we designed a UI related to counting the access cards to remind players how many they have already collected. And we also carefully optimized the menu scene. About the problem of difficult to get rid of ghosts, we have added a limited time acceleration function to the character which is illustrated to players before starting the game.


10.References and external resources that you used
Factory Construction
https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-construction-kit-modular-159280

Procedural generation:
https://www.youtube.com/watch?v=tyS7WKf_dtk&list=PLuldlT8dkudoNONqbt8GDmMkoFbXfsv9m&index=4


Camera reference:
https://www.codegrepper.com/code-examples/csharp/first+person+camera+unity

Render reference:
https://www.youtube.com/watch?v=hDJQXzajiPg 

Shader:
https://www.youtube.com/watch?v=5n_hmqHdijM&t=219s 

Toon Shading:
https://roystan.net/articles/toon-shader.html

Audio:
https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/ 

https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/

URP:
https://www.youtube.com/watch?v=gRq-IdShxpU

URP vs standard render:
https://forum.unity.com/threads/urp-vs-standard-render.852004/ 


## Future direction

1.We found that when the game is build and run and the ghoul chase the player, there is a chance that it will get stuck in the wall. However it will not happen in the editor mode. We thought that it is caused by the tracking algorithm of the ghoul. This problem may be solved by optimize the tracking algorithm of ghouls. The transition between the ghoul tracking algorithm and the NavMesh Agent component can be further optimized in the future. 

2.The role model and the map model can be more harmonious.




