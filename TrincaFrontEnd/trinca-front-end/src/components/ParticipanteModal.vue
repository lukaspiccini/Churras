<template>
    <b-modal
      id="modal"
      title="Informações do Participante"
      @ok="processaParticipante"
      @shown="configModal"
      @hide="sendEvent"
    >
      <form @submit.stop.prevent="handleSubmit">
        <b-form-input v-model="nome" placeholder="Nome" class="mt-2"></b-form-input>
        <input type="number" v-model="contribuicao" placeholder="Valor da contribuição" class="mt-2 form-control"/>
        <b-form-checkbox v-model="comBebida" class="mt-2">Com bebida</b-form-checkbox>
        <b-form-checkbox v-model="pago" class="mt-2">Pago</b-form-checkbox>
      </form>
    </b-modal>
</template>

<script>
export default {
    props: {
        churrasId: Number,
        participante: Object,
    },

    data() {
        return {
            participanteId: '',
            nome: '',
            contribuicao: '',
            comBebida: false,
            pago: false,
            isEditing: false
        }
    },

    methods: {
        configModal() {
            if(this.$props.participante.participanteId) {
                this.isEditing = true
                this.participanteId = this.$props.participante.participanteId;
                this.nome = this.$props.participante.nome;
                this.contribuicao = this.$props.participante.contribuicao;
                this.comBebida = this.$props.participante.comBebida;
                this.pago = this.$props.participante.pago;
            } else {
                this.isEditing = false;
            }
        },
        limpaCampos() {
            this.nome = '';
            this.contribuicao = '';
            this.comBebida = false;
            this.pago = false;
            this.isEditing = false;
        },
        processaParticipante(bvModalEvt) {
            if (!this.nome) {
               alert('Por favor, informe um nome')
            } else if (!this.contribuicao) {
                alert('Por favor, informe um valor de contribuição')
            } else {
                let participante = {
                    churrasId: this.$props.churrasId,
                    nome: this.nome, 
                    contribuicao: this.contribuicao,
                    comBebida: this.comBebida,
                    pago: this.pago
                };

                if(this.isEditing) 
                    this.$store.dispatch('editParticipante',{...participante, participanteId: this.participanteId})
                else
                    this.$store.dispatch('cadastraParticipante',participante)

                this.limpaCampos();
            }
        },
        sendEvent() {
            this.$emit('fechandoModal');
            this.limpaCampos()
        }
    },
}
</script>

<style scoped>

</style>
