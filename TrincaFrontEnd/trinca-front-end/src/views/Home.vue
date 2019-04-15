<template>
  <b-row>
    <Churras></Churras>
    <b-col xl="10" lg="10" md="10" sm="10" xs="10" offset="1" class="mt-5">
      <p class="header">Próximos Churras</p>

      <b-table per-page="10" outlined hover stripped fixed :items="allChurras" :fields="fields" :current-page="currentPage">
        <template slot="data" slot-scope="row">
          {{ new Date(row.item.data).toLocaleDateString() }}
        </template>

        <template slot="acoes" slot-scope="row">
          <b-button variant="primary" @click="info(row.item.churrasId)" class="mr-1">
            <i class="fas fa-users"></i>
          </b-button>
          <b-button variant="danger" @click="deleteChurras(row.item.churrasId)">
            <i class="fas fa-times"></i>
          </b-button>
        </template>
      </b-table>

      <b-row>
        <b-col xl="6" lg="6" md="6" sm="6" xs="6" class="my-2">
          <b-button variant="success" v-b-modal.modal>Adicionar novo Churras</b-button>
        </b-col>

        <b-col xl="6" lg="6" md="6" sm="6" xs="6" class="my-2">
          <b-pagination
            v-model="currentPage"
            :total-rows="allChurras.length"
            per-page="10"
            class="my-0 float-right"
          ></b-pagination>
        </b-col>
      </b-row>
    </b-col>
  </b-row>
</template>

<script>
import ChurrasModal from '../components/ChurrasModal';

export default {
  components: {
      'Churras': ChurrasModal
  },

  data() {
    return {
      fields: ['titulo','observacoes','data', 'acoes'],
      currentPage: 1,
    }
  },

  computed: {
    allChurras() {
      return this.$store.getters.allChurras;
    }
  },

  methods: {
    info(churrasId) {
      this.$router.push({name: 'churras', params: {churrasId: churrasId}})
    },
    deleteChurras(churrasId) {
      this.$store.dispatch('deleteChurras',churrasId);
    }
  },
  
  mounted() {
    this.$store.dispatch('getAllChurras');
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
