using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts._13_Coroutine
{
    class pr_Coroutine : MonoBehaviour
    {
        private UnityEngine.Coroutine coroutineExample = null;

        private void Start()
        {
            coroutineExample = StartCoroutine(CoroutineExample());
            StartCoroutine(CountCoroutine());
            StartCoroutine("CountCoroutine");
        } // end of Start()
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StopCoroutine(coroutineExample);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                StopCoroutine("CountCoroutine");
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                StopAllCoroutines();
            }
        } // end of Update()
        private IEnumerator CoroutineExample()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                yield return null;
            }
        } // end of CoroutineExample()
        private IEnumerator CountCoroutine()
        {

            yield return null;
            yield break;
        } // end of CountCoroutine()

    } // end of class

}
