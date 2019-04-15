<template>
  <b-row>
    <b-col xl="10" lg="10" md="10" sm="10" xs="10" offset="1" class="mt-5">
      <Participante 
        @fechandoModal="limpaParticipante()"
        :churrasId="parseInt(this.churrasId)"
        :participante="this.participante" 
      >
      </Participante>

      <p class="header">
        <router-link to="/"><i class="fas fa-arrow-left"></i></router-link>
        Participantes
      </p>

      <b-table per-page="5" :current-page="currentPage" outlined hover stripped fixed :items="allParticipantes" :fields="fields">
        <template slot="comBebida" slot-scope="row">
          <b-form-checkbox
            id="checkbox-1"
            v-model="row.item.comBebida"
            name="checkbox-1"
            value="true"
            unchecked-value="false"
            disabled
          >
          </b-form-checkbox>
        </template>
        
        <template slot="pago" slot-scope="row">
          <b-form-checkbox
            id="checkbox-2"
            v-model="row.item.pago"
            name="checkbox-1"
            value="true"
            unchecked-value="false"
            disabled
          >
          </b-form-checkbox>
        </template>

        <template slot="acoes" slot-scope="row">
          <b-button variant="primary" v-b-modal.modal @click="editParticipante(row.item)" class="mr-1">
            <i class="fas fa-edit"></i>
          </b-button>
          <b-button variant="danger" @click="deleteParticipante(row.item.participanteId)">
            <i class="fas fa-times"></i>
          </b-button>
        </template>
      </b-table>

      <b-row class="my-4">
        <b-col xl="6" lg="6" md="6" sm="6" xs="6" class="my-2">
          <b-button variant="success" v-b-modal.modal>Adicionar novo Participante</b-button>
        </b-col>

        <b-col xl="6" lg="6" md="6" sm="6" xs="6" class="my-2">
          <b-pagination
            v-model="currentPage"
            :total-rows="allParticipantes.length"
            per-page="5"
            class="my-0 float-right"
          ></b-pagination>
        </b-col>
      </b-row>

      <p><b>Total de participantes</b>: {{ totalParticipantes }}</p>
      <p><b>Total Arrecadado</b>: R$ {{ totalArrecadado }}</p>
      <p><b>Total de Bebuns</b>: {{ totalBebuns }}</p>
      <p><b>Total de Saudáveis</b>: {{ totalSaudaveis }}</p>

    </b-col>
  </b-row>
</template>

<script>
import ParticipanteModal from '../components/ParticipanteModal';

export default {
  components: {
    'Participante': ParticipanteModal
  },

  data() {
    return {
      churrasId: 0,
      fields: ['nome','contribuicao', 'comBebida', 'pago', 'acoes'],
      currentPage: 1,
      participante: {}
    }
  },
  methods: {
    editParticipante(participante) {
      this.participante = participante;
    },
    deleteParticipante(participanteId) {
      this.$store.dispatch('deleteParticipante', 
                                    {
                                      participanteId: participanteId,
                                      churrasId: this.churrasId
                                    });
    },
    limpaParticipante() {
      this.participante = {}
    }
  },
  computed: {
    allParticipantes() {
      return this.$store.getters.allParticipantesChurras;
    },

    totalParticipantes() {
      return this.allParticipantes.length
    },

    totalArrecadado() {
      return this.allParticipantes.reduce((prevVal, elem) => {
        return elem.pago ? prevVal + elem.contribuicao : prevVal + 0
      }, 0);
    },

    totalBebuns() {
      let bebuns = this.allParticipantes.filter( x => {
        return x.comBebida
      });

      return bebuns.length;
    },

    totalSaudaveis() {
      let saudaveis = this.allParticipantes.filter( x => {
        return !x.comBebida
      });

      return saudaveis.length;
    }
  },
  mounted() {
    this.churrasId = this.$route.params.churrasId;
    this.$store.dispatch('getParticipantesChurras', this.churrasId);
  }
}
</script>

<style scoped>
  .header {
    font-family: 'Russo One', sans-serif;
    font-size: 30px;
    color: #AC3D1B;
  }
</style>

