using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    // Propriedades Lógicas
    private string label;
    private List<Link> inList;
    private List<Link> outList;

    // Propriedades Gráficas
    private GameObject nodeGameObject;    

    // Update is called once per frame
    void Update () {

    }

public Node() {
    this.label = "Vazio";
}
    // Construtor de aridade 1
    public Node (string label, GameObject obj) {
        this.label = label;
        this.inList = new List<Link> ();
        this.outList = new List<Link> ();
        this.nodeGameObject = obj;
    }

    // Getter da propriedade label
    public string getLabel () {
        return this.label;
    }

    // Getter da propriedade nodeGameObject
    public GameObject getNodeGameObject () {
        return this.nodeGameObject;
    }

    // Getter da propriedade inList
    public List<Link> getInList () {
        return this.inList;
    }

    // Getter da propriedade outList
    public List<Link> getOutList () {
        return this.outList;
    }

    // Adiciona link à inList
    public void addInlist (Link link) {
        this.inList.Add (link);
    }

    // Adiciona link à outList
    public void addOutlist (Link link) {
        this.outList.Add (link); 
    }

    
}