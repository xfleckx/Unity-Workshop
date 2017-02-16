### Using Unity for scientific demonstrators and research projects

#VSLIDE

### Contents

1. Setting up a project _(10 min)_
2. Delegating work with (git) submodules and prefabs _(30 min)_
3. Advanced coding tips for rapid prototyping
    1. UnityEvents _(10 min)_
    2. Coroutines _(20 min)_
    3. Linq _(20 min)_
4. Editor scripting and advanced debugging _(20 min)_

#VSLIDE

### Setting up project

Unity + git

#VSLIDE

- Reduce merge conflicts

#HSLIDE

### Case A

Unity project only

2-3 Collaborators

#VSLIDE

![Logo](img/repo_case_a.jpg)

#HSLIDE

### Case B

Unity project depending on a _work in progress_ asset package

2-3 Collaborators

1 maintainer of the asset package 

#VSLIDE

```bash
git submodule add -b master 
                  --name UnityToolbag 
                  git://github.com/nickgravelyn/UnityToolbag.git 
                  ResearchDemonstrator/Assets/UnityToolbag 

```


#HSLIDE 




### UnityEvents

#HSLIDE

### Coroutine

#HSLIDE

### Linq

#HSLIDE



###