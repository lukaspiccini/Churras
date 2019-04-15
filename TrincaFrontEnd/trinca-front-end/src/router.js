import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Churras from './views/Churras.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/churras/:churrasId',
      name: 'churras',
      component: Churras
    }
  ]
})
