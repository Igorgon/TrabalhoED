using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Link : MonoBehaviour {

	//Propriedades lógicas
	private float weight;
	private Node to;
	private Node from;

	// Propriedades Gráficas
	private RectTransform graphContainer;
	private GameObject linkGameObject;

	// Update is called once per frame
	void Update () {

	}

	// Construtor de aridade 4
	public Link (Node from, Node to, float weight, GameObject link) {
		this.to = to;
		this.from = from;
		this.weight = weight;
		this.linkGameObject = link;
	}

	// Getter da propriedade 'to'
	public Node getTo () {
		return this.to;
	}

	// Getter da propriedade 'weight'
	public float getWeight () {
		return this.weight;
	}

	// Getter da propriedade linkGameObject
	public GameObject getLinkGameObject () {
		return this.linkGameObject;
	}

	
}