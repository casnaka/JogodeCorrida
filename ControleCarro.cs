using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCarro : MonoBehaviour
{
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;

    public Light LuzFreioEsquerda; 
    public Light LuzFreioDireita;  

    public float aceleracao = 500f;
    public float freio = 300f;
    public float anguloTorque = 15f;

    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;


    private void FixedUpdate()
    {
        aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
        aceleracaoAtual *= -1; // Inverter a direção da aceleração
        RodaFrenteDireita.motorTorque = aceleracaoAtual;
        RodaFrenteEsquerda.motorTorque = aceleracaoAtual;

        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
        RodaFrenteDireita.steerAngle = anguloTorqueAtual;
        RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        if (Input.GetKey(KeyCode.Space))
        {
            freioAtual = freio;
        }
        else
        {
            freioAtual = 0f;
        }

        RodaFrenteDireita.brakeTorque = freioAtual;
        RodaFrenteEsquerda.brakeTorque = freioAtual;
        RodaTraseiraDireita.brakeTorque = freioAtual;
        RodaTraseiraEsquerda.brakeTorque = freioAtual;

        // Código para ligar a luz de freio quando freiarmos o carro
        if (Input.GetKey(KeyCode.Space)) 
        {
            LuzFreioEsquerda.intensity = 1;
            LuzFreioDireita.intensity = 1;
        }
        else 
        {
            LuzFreioEsquerda.intensity = 0;
            LuzFreioDireita.intensity = 0;
        }
    }
}
