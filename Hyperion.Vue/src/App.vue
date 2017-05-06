<template>
  <div id="app">
    <top-head></top-head>
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-2 col-sm-3 sidebar">
          <nav-menu></nav-menu>
        </div>          
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import 'bootstrap/dist/css/bootstrap.css'
import './assets/css/hyperion.css'
import $ from 'jquery'
import TopHead from './components/Head'
import NavMenu from './components/NavMenu'

export default {
  name: 'app',
  components: {
    TopHead,
    NavMenu
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
