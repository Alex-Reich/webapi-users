<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App',
  mounted() {
    this.$store.dispatch("authenticate")
  },
  computed: {
    user(){
      return this.$store.state.user
    }
  }
}
</script>

<style>
#app {
  font-family: 'Bungee Inline', cursive;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 20px;
}
</style>
