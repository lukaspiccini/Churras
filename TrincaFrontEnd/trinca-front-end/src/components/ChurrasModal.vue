<template>
    <b-modal
      id="modal"
      title="Cadastre um novo Churras"
      @ok="cadastraChurras"
      @shown="limpaCampos"
    >
      <form @submit.stop.prevent="handleSubmit">
        <b-form-input v-model="titulo" placeholder="Titulo do churras" class="mt-2"></b-form-input>
        <b-form-input type="date" v-model="data" placeholder="Data do churras" class="mt-2"></b-form-input>
        <b-form-textarea v-model="observacoes" placeholder="Observacoes" class="mt-2"></b-form-textarea>

      </form>
    </b-modal>
</template>

<script>
export default {
    data() {
        return {
            titulo: '',
            data: '',
            observacoes: ''
        }
    },

    methods: {
        limpaCampos() {
            this.titulo = '';
            this.data = '';
            this.observacoes = '';
        },
        cadastraChurras(bvModalEvt) {
            if (!this.titulo) {
               alert('Por favor, informe um titulo')
            } else if (!this.data) {
                alert('Por favor, informe uma data')
            } else if (!this.observacoes) {
                alert('Por favor, informe uma observação')
            } else {
                this.$store.dispatch('cadastraChurras',{titulo: this.titulo, data: this.data, observacoes: this.observacoes});
                this.limpaCampos();
            }

        }
    }
}
</script>

<style scoped>

</style>
