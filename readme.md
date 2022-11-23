<div align="center">

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity3d.com)
# Ground Impact Destruction 2D

A lib for creating destruction in a 2D ground using squares and parallelepipeds.
</div>

![image](/docs/img_example.png)

## How it works

Recreate the polygon collider of an object based on impacts.

## How it does this

The lib implements a class that uses a linked list to track all the impacts positions in the object. Every time that the object receive an impact, this position is set to a ordened place inside the linked list.

After doing this, the class create an array of vectors that can be used by the polygon collider to recreate the polygon format of the object.

## When it works

For now, the lib can handle with square and parallelepiped ground formats. Also, just create square and parallelepiped destruction in the ground. Besides that, the lib can't handle with increasing of the "holes" in the object. Can you contribute with this project? Send a PR (:

## Flow

![image](/docs/flow.png)