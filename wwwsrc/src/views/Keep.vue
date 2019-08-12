<template>
  <div class="KeepView">
    <h1>Total Keeps: {{keep.views}}</h1>
  </div>
</template>


<script>

  export default {
    name: "Keep",
    props: [],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getKeepById", this.$route.params.id)
    },
    computed: {
      keep() {
        return this.$store.state.keep
      }
    },

    methods: {

    },
    components: {

    }
  }


</script>


<style>


</style>