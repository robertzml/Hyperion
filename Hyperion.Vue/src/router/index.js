import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Vendor from '@/components/Vendor'
import User from '@/components/User'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    }, {
      path: '/vendor',
      name: 'vendor',
      component: Vendor
    }, {
      path: '/user',
      name: 'user',
      component: User
    }
  ]
})
