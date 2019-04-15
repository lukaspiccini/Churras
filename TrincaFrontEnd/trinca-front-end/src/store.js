import Vue from 'vue'
import Vuex from 'vuex'
import { getAllChurras, deleteChurras, cadastraNovoChurras } from '../services/churrasApiService'
import { getAllParticipantes, deleteParticipante, cadastraNovoParticipante, editParticipante } from '../services/participantesApiService'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    churras: [],
    participantes: []
  },
  getters: {
    allChurras(state) {
      return state.churras;
    },

    allParticipantesChurras(state) {
      return state.participantes;
    }
  },

  mutations: {
    getAllChurras(state, churras) {
      state.churras = churras;
    },

    getParticipantesChurras(state, participantes) {
      state.participantes = participantes;
    }
  },

  actions: {
    async getAllChurras(context) {
      try {
        let churras = await getAllChurras();
        context.commit('getAllChurras', churras);
        
      } catch(e) {
        console.log(e);
      }
    },

    async deleteChurras(context,churrasId) {
      try {
        let result = await deleteChurras(churrasId);
        if(result.valido) 
          context.dispatch('getAllChurras');

      } catch(e) {
        console.log(e);
      }
    },

    async cadastraChurras(context, churras) {
      try {
        await cadastraNovoChurras(churras);
        context.dispatch('getAllChurras');

      } catch(e) {
        console.log(e);
      }
    },

    async getParticipantesChurras(context, churrasId) {
      try {
        let participantes = await getAllParticipantes(churrasId);
        context.commit('getParticipantesChurras', participantes);

      } catch(e) {
        console.log(e);
      }
    },

    async cadastraParticipante(context, participante) {
      try {
        var novoParticipante = await cadastraNovoParticipante(participante);
        context.dispatch('getParticipantesChurras', novoParticipante.churrasId);

      } catch(e) {
        console.log(e);
      }
    },

    async deleteParticipante(context, payload) {
      try {
        var result = await deleteParticipante(payload.participanteId);
        if (result.valido) 
          context.dispatch('getParticipantesChurras', payload.churrasId);

      } catch(e) {
        console.log(e);
      }
    },

    async editParticipante(context, participante) {
      try {
        var result = await editParticipante(participante); 
        context.dispatch('getParticipantesChurras', participante.churrasId);

      } catch(e) {
        console.log(e);
      }
    },
  }
})
