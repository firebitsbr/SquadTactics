﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {
    
    // O modo em que a arma estar.
    private bool modoFull;

    // Start is called before the first frame update
    new void Start() {
        this.capacidade = 32;
        this.podeAtirar = true;
        this.modoFull = false;
    }

    // Update is called once per frame
    new void Update() {

        /*if (this.capacidade == 0) {
            if (this.tempo < 3) {
                this.tempo += Time.deltaTime;
            } else {
                this.tempo = 0;
                this.capacidade = 32;
            }
        }*/

        if (Input.GetButtonDown("W")) {
            this.AtivarModoFull();
        }

        if (Input.GetButtonDown("Q")) {
            this.AtivarModoNormal();
        }

        if (this.capacidade == 0) {
            StartCoroutine(Recarregar());
        }
    }

    public override void Atirar() {
        if (this.podeAtirar) {
            if (!this.modoFull) {
                this.podeAtirar = false;
                int sorteio = (int)Random.Range(4, 7);
                StartCoroutine(Disparar(sorteio, 1));
            } else {
                this.podeAtirar = false;
                StartCoroutine(Disparar(32, 5));
            }
        }
    }

    private IEnumerator Disparar(int vezes, int tempoPraVoltarAtirar) {
        for (int i = 0; i < vezes; i++)
        {
            if (this.capacidade > 0)
            {
                Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
                this.capacidade--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(tempoPraVoltarAtirar);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar() {
        yield return new WaitForSeconds(3);
        this.capacidade = 32;
    }

    public void AtivarModoFull() {
        this.modoFull = true;
    }

    public void AtivarModoNormal() {
        this.modoFull = false;
    }

}
