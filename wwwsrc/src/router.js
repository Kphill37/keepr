import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import createKeep from './views/createKeep.vue'
// @ts-ignore
import myAccount from './views/myAccount.vue'
// @ts-ignore
import createVault from './views/createVault.vue'
// @ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/createKeep',
      name: 'createKeep',
      component: createKeep,
    },
    {
      path: '/myAccount',
      name: 'myAccount',
      component: myAccount,
    },
    {
      path: '/createVault',
      name: 'createVault',
      component: createVault,
    },
    {
      path: '/Keep',
      name: 'Keep',
      component: Keep,
    },
  ]
})
