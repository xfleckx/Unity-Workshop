### Using Unity for scientific demonstrators and research projects

#HSLIDE

### Contents

1. Setting up a project _(10 min)_
2. Delegating work with (git) submodules and prefabs _(30 min)_
3. Advanced coding tips for rapid prototyping
    1. UnityEvents _(10 min)_
    2. Coroutines _(20 min)_
    3. Linq _(20 min)_
4. Editor scripting and advanced debugging _(20 min)_

#HSLIDE

### Setting up project

Unity + git

#VSLIDE

- add .gitignore 
- exceptions: plugin.dll
```shell
git add -f Assets/<fizzBuzz>/Plugins/<plugin>.dll
```

#VSLIDE

- Reduce merge conflicts
Reduce merge conflicts with prefabs

Copy -> Change -> Ready to replace

#HSLIDE

Each feature should be developed in an dedicated scene.
Dev-Scene in Development branch

Unity project depending on a _work in progress_ asset package

#VSLIDE?image=img/overview.png

#HSLIDE

### Using prefabs

- distinct logical entities 
- containing serialized state 
- state => value + references

#VSLIDE

add a usefull project as submodule...

```bash
git submodule add -b master 
                  --name UnityToolbag 
                  git://github.com/nickgravelyn/UnityToolbag.git 
                  ResearchDemonstrator/Assets/UnityToolbag 
```


### Designing a prefab

- use a top level script as facade
- use public methods 
- use events for deferred results 

#HSLIDE

### CODING

#VSLIDE

### UnityEvents

#HSLIDE

### Coroutines

#HSLIDE

### Linq

#HSLIDE

### Editor scripting

#VSLIDE

### Building a custom debugger

- get rid of Debug.Log() messages
- a window showing different states of several objects