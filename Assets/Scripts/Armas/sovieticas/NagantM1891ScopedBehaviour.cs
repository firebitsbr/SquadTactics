﻿using UnityEngine;
using System.Collections;
using System;

public class NagantM1891ScopedBehaviour : WeaponBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 5;
        this.danoPequena = 30;
        this.danoMedio = 22.5f;
        this.danoLongo = 15;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            if (this.capacidade == 0)
            {
                StartCoroutine(Recarregar());
            } else
            {
                int tempo = UnityEngine.Random.Range(6, 8);
                StartCoroutine(Disparar(alvo, tempo));
            }
        }
    }

    private IEnumerator Disparar(PlayerBehaviour alvo, int tempo)
    {
        Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
        this.capacidade--;
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 5;
        this.podeAtirar = true;
    }

    public override void AtivarOuDesativarHabilidade()
    {
        // Feels :(
    }
}
