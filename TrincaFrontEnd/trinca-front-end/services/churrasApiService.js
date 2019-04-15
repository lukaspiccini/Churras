import axios from 'axios'
const dotenv = require('dotenv').config();

export async function getAllChurras() {
    try {
        let churras = await axios.get(`${process.env.VUE_APP_BASE_URL_API}/churras`);
        return churras.data;
    } catch(e) {
        console.log(e);
    }
}

export async function deleteChurras(churrasId) {
    try {
        let churras = await axios.delete(`${process.env.VUE_APP_BASE_URL_API}/churras/${churrasId}`);
        return churras.data;
    } catch(e) {
        console.log(e);
    }
    
}

export async function cadastraNovoChurras(churras) {
    try {
        let novoChurras = {
            titulo: churras.titulo,
            data: churras.data,
            observacoes: churras.observacoes
        }

        let result = await axios.post(`${process.env.VUE_APP_BASE_URL_API}/churras`, novoChurras);
        return result.data;
    } catch(e) {
        console.log(e);
    }
    
}
