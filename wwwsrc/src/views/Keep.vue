<template>
  <div class="container-fluid KeepView">
    <div class="row">
      <div class="col-lg-6 col-md-12">
        <div class="card">
          <div class="card-title">
            {{keep.name}}
          </div>
          <img class="card-img-top" :src="keep.img" alt="keep.name">
          <div class="card-body">

            <p class="card-text">{{keep.description}}
            </p>
          </div>
        </div>
      </div>
      <div class="col-lg-6 col-md-12 keepStats">
        <ul>
          <li style="background-color: pink">
            Views: {{keep.views}}
          </li>
          <li style="background-color: rgb(61, 212, 250);">
            Shares: {{keep.shares}}
          </li>
          <li style="background-color: pink;">
            Keeps: {{keep.keeps}}
          </li>
        </ul>
      </div>
    </div>
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


<style scoped>
  .keepImg {
    margin-top: 1vh;
    margin-left: 2vh;
    border: 5px groove black;
  }

  img {
    margin-left: 2vw;
    max-height: 30rem;
    max-width: 19rem;
  }

  li {
    list-style-type: none;
    width: 20vw;
    margin-bottom: 11vh;
  }

  .card {
    margin-top: 10vh;
    margin-left: 7vw;
    margin-bottom: 5vh;
    height: auto;
    width: 25rem;
  }

  .keepStats {
    margin-left: 0vw;
    margin-top: 21vh;
    font-size: 3rem
  }

  .card-text {
    font-weight: bold;
    font-size: 2rem;
  }

  .card-title {
    font-weight: bold;
    font-size: 2rem;
  }
</style>