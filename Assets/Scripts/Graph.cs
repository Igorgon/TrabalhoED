using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour {

	// Propriedades gráficas
	private RectTransform graphContainer;
	[SerializeField]
    private Sprite circleSprite;

	// Propriedades lógicas
	private List<Node> nodes;
	private bool directed;

	private void Awake () {
		this.directed = false;
		this.nodes = new List<Node>();
		graphContainer = transform.Find ("GraphContainer").GetComponent<RectTransform> ();
		List<int> xPos = new List<int> () { 100, 100, 200, 200 };
		List<int> yPos = new List<int> () { 100, 200, 100, 200 };
		showGraph (xPos, yPos);
	}

	void Update () {

	}

	// Get da propriedade 'nodes'
	public List<Node> GetNodes () {
		return this.nodes;
	}

	// Get da propriedade 'directed'
	public bool GetDirected () {
		return this.directed;
	}

	// Adiciona um nó ao grafo
	public void addNode (string label) {
		this.nodes.Add (new Node (label, createNodeGameObject(new Vector2 (500, 300)))); // Vai ter uma função para calcular a posição de novos nós a serem inseridos
	}

	// A seguir mátodos que ainda não foram testados
	#region "Não testado"

	// Busca nó de label 'label' no grafo 
	 public Node findNode (string label) {
	 	return  this.nodes.Find (item => item.getLabel() == label);
	 }

	// Adiciona um link de peso weight do nó 'from' ao nó 'to' 
	public void addLinkFromTo (Node from, Node to, float weight) {
		Link toFrom = new Link (from, to, weight, createLinkGameObject(from.getNodeGameObject().transform.position, to.getNodeGameObject().transform.position ));
		Link fromTo = new Link (to, from, weight, createLinkGameObject(to.getNodeGameObject().transform.position, from.getNodeGameObject().transform.position ));

		// Encontra nó origem e adiciona à sua outList o nó destino
		this.findNode (from.getLabel ()).addOutlist (fromTo);
		// Encontra o nó destino e adiciona à sua inList o nó origem
		this.findNode (to.getLabel ()).addInlist (toFrom);

		// Se o grafo não é direcionado
		if (!this.directed) {
			// Encontra o nó origem e e adiciona à sua inList o nó destino
			this.findNode (from.getLabel ()).addInlist (fromTo);
			// Encontra o nó destino e e adiciona à sua outList o nó origem
			this.findNode (to.getLabel ()).addOutlist (toFrom);
		}
	}

	#endregion

	// A seguir mátodos que ainda não foram implementados
	#region "Não implementado"

	// Adiciona um link de peso weight do nó 'from' ao nó 'to' 
	public void removeLink (Link link) {
		Debug.Log ("Nao implementado");
	}

	// Encontra a maior ou menor rota entre dois nós
	public void FindRoute (Node from, Node to, bool longest) {
		Debug.Log ("Nao implementado");
	}

	#endregion


	private void showGraph (List<int> xList, List<int> yList) {
		Node lastObj = new Node();
		for (int i = 0; i < xList.Count; i++) {
			Node node = new Node ("Teste", createNodeGameObject(new Vector2 (xList[i], yList[i])));
			this.nodes.Add(node);
			if (lastObj.getLabel() != "Vazio") {
				Link link = new Link (lastObj, node, 100f, createLinkGameObject(new Vector2 (xList[i-1], yList[i-1]), new Vector2 (xList[i], yList[i])));	
				node.addInlist(link);
				node.addOutlist(link);
				lastObj.addInlist(link);
				lastObj.addOutlist(link);
			}
			lastObj = node;
		}
	}

	private GameObject createNodeGameObject (Vector2 anchoredPosition) {
        GameObject nodeGameObject = new GameObject ("circle", typeof (Image));
        nodeGameObject.transform.SetParent (this.graphContainer);
        nodeGameObject.GetComponent<Image> ().sprite = this.circleSprite;
        RectTransform rectTransform = nodeGameObject.GetComponent<RectTransform> ();

        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2 (50, 50);
        rectTransform.anchorMin = new Vector2 (0, 0);
        rectTransform.anchorMax = new Vector2 (0, 0);

        // Criar label para o nome do bloco
		return nodeGameObject;
    }

private GameObject createLinkGameObject (Vector2 posA, Vector2 posB) {
		GameObject linkGameObject = new GameObject ("aresta", typeof (Image));
		linkGameObject.transform.SetParent (this.graphContainer);
		linkGameObject.GetComponent<Image> ().color = new Color (1, 1, 1, 0.5f);
		RectTransform rectTransform = linkGameObject.GetComponent<RectTransform> ();
		Vector2 direction = (posB - posA).normalized;
		float distance = Vector2.Distance (posA, posB);
		rectTransform.anchorMin = new Vector2 (0, 0);
		rectTransform.anchorMax = new Vector2 (0, 0);
		rectTransform.sizeDelta = new Vector2 (120, 3f);
		rectTransform.anchoredPosition = posA + direction * distance * 0.5f;
		rectTransform.localEulerAngles = new Vector3 (0, 0, float.Parse ((Math.Atan (direction.y / direction.x) * 180 / Math.PI).ToString ()));

		// Criar label para distancia do link 
		return linkGameObject;
	}
}