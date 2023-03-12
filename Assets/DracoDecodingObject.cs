// Copyright 2017 The Draco Authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//using Unity.Burst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

[BurstCompile]
public struct DracoJob : IJob
{
    public NativeArray<byte> bytes;
    public void Execute()
    {
       // DracoMeshLoader dracoLoader = new DracoMeshLoader();
       // dracoLoader.TestJob(bytes.ToArray());
        Debug.Log("DracoJob Execute");
    }
}

public class DracoDecodingObject : MonoBehaviour {
    public DracoMeshLoader dracoLoader;
    public TextAsset textAsset;

  // This function will be used when the GameObject is initialized.
  void Start() {

        dracoLoader = new DracoMeshLoader();
        updateMesh();

        //DracoMeshLoader dracoLoader = new DracoMeshLoader();
        ///*
        // * Here we use the compressed Bunny model as example.
        // * It's in unity/Resources/bunny.drc.bytes.
        // * Please see README.md for details.
        // */
        //int numFaces = dracoLoader.LoadMeshFromAsset("bunny.drc", ref mesh);

    /* Note: You need to add MeshFilter (and MeshRenderer) to your GameObject.
     * Or you can do something like the following in script:
     * AddComponent<MeshFilter>();
     */

  }

    public void Update()
    {
        //updateMesh();

        int l = textAsset.bytes.Length;
        NativeArray<byte> b = new NativeArray<byte>(l, Allocator.TempJob);
        b.CopyFrom(textAsset.bytes);
        DracoJob dracoJob = new DracoJob
        {
            bytes = b
        };

        JobHandle jobHandle = dracoJob.Schedule();
        jobHandle.Complete();
        b.Dispose();
        //GetComponent<MeshFilter>().mesh = dracoJob.mesh;
    }

    public void  updateMesh() {

        //DracoMeshLoader dracoLoader = new DracoMeshLoader();
        dracoLoader.TestJob(textAsset.bytes);

        //GetComponent<MeshFilter>().mesh = dracoLoader.LoadMeshFromAsset("test.obj.drc");
    }
}
