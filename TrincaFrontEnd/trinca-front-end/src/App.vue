<template>
  <div id="app">
    <b-row>
      <b-col xl="6" lg="12" md="12" sm="12" class="left-panel">
        <div class="my-row m-5">
          <label class="line radius-left"></label>
          <p class="text-welcome">BEM VINDO AO</p>
          <label class="line radius-right"></label>
        </div>

        <div class="my-row m-5">
          <label class="left-flag"></label>
          <label class="text-bbq">CHURRASCOMETRO</label>
          <label class="right-flag"></label>
        </div>
        
        <p class="text-logo">TRI</p>
        <p class="text-logo">NCA</p>

        <p class="text-subtitle my-5">483L de <i class="fas fa-beer"></i> já foram consumidos</p>
        <p class="text-subtitle my-5">Já devoramos 120KG de <i class="fas fa-drumstick-bite"></i></p>
      </b-col>

      <b-col xl="6" lg="12" md="12" sm="12" class="teste2">
      <router-view/>

      </b-col>
    </b-row>
  </div>
</template>

<style>
  .my-row {
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .line {
    width: 150px;
    height: 20px;
    background: #770B0B;
    margin-left: 10px;
    margin-right: 10px;
  }

  .radius-left {
    border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
  }

  .radius-right {
    border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;
  }

  .left-flag {
    width: 80px;
    height: 60px;
    position: relative;
    background: #770B0B;
    margin-right: 10px;
  }

  .left-flag:after {
    content: "";
    position: absolute;
    left: 0;
    bottom: 0;
    width: 0;
    height: 0;
    border-left: 30px solid #3E0808;
    border-top: 30px solid transparent;
    border-bottom: 30px solid transparent;
  }

  .right-flag {
    width: 80px;
    height: 60px;
    position: relative;
    background: #770B0B;
    margin-left: 10px;
    transform: rotate(180deg);
  }
  .right-flag:after {
    content: "";
    position: absolute;
    left: 0;
    bottom: 0;
    width: 0;
    height: 0;
    border-left: 30px solid #3E0808;
    border-top: 30px solid transparent;
    border-bottom: 30px solid transparent;
  }
  
  .left-panel {
    background-color: #3E0808;
    color: #AC3D1B;
    text-align: center;
    /* border: 14px solid #770B0B; */
  }

  .text-welcome {
    font-family: 'Russo One', sans-serif;
    font-style: normal;
    font-weight: normal;
    font-size: 50px;
    line-height: normal;
    text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  }

  .text-subtitle {
    font-family: 'Russo One', sans-serif;
    font-style: normal;
    font-weight: normal;
    font-size: 40px;
    line-height: normal;
    text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  }

  .text-bbq {
    font-family: 'Rye', cursive;
    font-style: normal;
    font-weight: normal;
    font-size: 3.5vw;
    line-height: normal;
    background-color: #770B0B;
    padding: 10px 10px;;
  }

  .arrow-left {
    width: 0; 
    height: 0; 
    border-top: 30px solid transparent;
    border-bottom: 30px solid transparent; 
    
    border-right:30px solid #770B0B; 
  }

  .arrow-right {
    border-top: 30px solid transparent;
    border-bottom: 30px solid transparent;
    
    border-left: 30px solid #770B0B;
  }

  .text-logo {
    font-family: 'Russo One', sans-serif;
    font-style: normal;
    font-weight: normal;
    font-size: 67px;
    line-height: normal;
    text-align: center;
    letter-spacing: 0.45em;
  }

  .teste2 {
    height: 100vh;
    /* border: 14px solid #770B0B; */
  }
</style>
