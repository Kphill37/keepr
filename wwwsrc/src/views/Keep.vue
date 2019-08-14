<template>
  <div class="KeepView container-fluid">
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
  /* .keepImg {
    margin-top: 1vh;
    margin-left: 1vw;
    border: 5px groove black;
  }

  img {
    margin-left: 1vw;
    margin-right: auto;
    max-height: 30rem;
    max-width: 19rem;
  }

  li {
    list-style-type: none;
    width: 100%;
    margin-bottom: 11vh;
  }

  ul {
    width: -10vw;
  }

  .card {
    height: auto;
    min-width: 20rem;
    margin: 20px auto;
  }

  .keepStats {
    margin-left: 0vw;
    margin-top: 21vh;
    font-size: 3rem;

  }

  .card-text {
    font-weight: bold;
    font-size: 2rem;
  }

  .card-title {
    font-weight: bold;
    font-size: 2rem;
  } */

  .card {
    height: auto;
    width: 75%;
    margin: 5vh auto;
  }

  img {
    height: 31vh;
    width: 60vw;
    margin: 0 auto;
  }

  .card-title {
    font-weight: bold;
    font-size: 2rem;
  }

  .card-text {
    font-weight: bold;
    font-size: 2rem;
  }

  .keepStats {
    margin-left: 0vw;
    margin-top: 5vh;
    font-size: 3rem;
  }

  ul {
    width: -10vw;
    margin-right: 6vw;
  }

  li {
    list-style-type: none;
    width: 100%;
    margin-bottom: 11vh;
  }
</style>