import axios from 'axios'
const dotenv = require('dotenv').config();


export async function getAllParticipantes(churrasId) {
    try {
        let participantes = await axios.get(`${process.env.VUE_APP_BASE_URL_API}/participante/${churrasId}`);
        return participantes.data;
    } catch(e) {
        console.log(e);
    }
}

export async function cadastraNovoParticipante(participante) {
    try {
        let result = await axios.post(`${process.env.VUE_APP_BASE_URL_API}/participante`, participante);
        return result.data;
    } catch(e) {
        console.log(e);
    }
}

export async function deleteParticipante(participante) {
    try {
        let result = await axios.delete(`${process.env.VUE_APP_BASE_URL_API}/participante/${participante}`);
        return result.data;
    } catch(e) {
        console.log(e);
    }
}

export async function editParticipante(participante) {
    try {
        let result = await axios.put(`${process.env.VUE_APP_BASE_URL_API}/participante`,participante);
        return result.data;
    } catch(e) {
        console.log(e);
    }
}
