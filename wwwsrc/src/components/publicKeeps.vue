<template>
  <div class="publicKeeps mt-2 ml-3 container-fluid w100">
    <div class="row">
      <div class="card col-lg-3 col-md-12 mb-5 mt-2 ml-2" v-if="!keep.isPrivate" v-for="keep in keeps">
        <h1>{{keep.id}}</h1>
        <img class="card-img-top">
        <div class="card-body" style="min-height: 18rem;">
          <h5 class="card-title pt-1">{{keep.name}}<br>
            <h6 style="font-size: 1rem">Views: {{keep.views}}</h6>
          </h5>

          <p class="card-text">{{keep.description}}</p>
          <img :src="getKeepImg(keep)" alt="Keep Image">
        </div>
        <div class="row keepControls">
          <div class="col-lg-12 col-md-12">
            <i class="fas fa-eye mr-6" @click="viewKeep(keep)">View</i> <i class="fas fa-share mr-6">Share</i> <i
              class="fas fa-heart mr-3" @click="vaulttoggle = !vaulttoggle">Keep</i>
          </div>
          <div v-if="vaulttoggle == true" class="row">
            <div class="col-lg-12 col-md-12 mt-5">
              <select class="selected mb-5" v-model="selected" @change="addVaultKeep(keep)">
                <option disabled value>Add To Vault</option>
                <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>

  import defaultIMG from '@/assets/200x200.png'

  export default {
    name: "publicKeeps",
    props: [],
    data() {
      return {
        selected: "",
        vaulttoggle: false
      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps")
      this.$store.dispatch("getUserVaults")
    },
    computed: {
      keeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.uservaults
      }
    },

    methods: {
      addVaultKeep(keep) {
        let vaultid = this.selected
        let keepid = keep.id
        this.$store.dispatch("iterateKeepCount", keep)
        this.$store.dispatch("addVaultKeep", { keepid, vaultid })
        this.selected = ''
      },
      getKeepImg(keep) {
        if (!keep.img) {
          return defaultIMG
        }
        return keep.img
      },
      viewKeep(keep) {
        this.$store.dispatch("updateKeepCount", keep)
        this.$router.push({ name: 'Keep', params: { id: keep.id } })
      }
    },
    components: {

    }
  }


</script>


<style>
  .card {
    border: 1px groove black;
    height: auto;
    width: 20rem;
    margin: 0 auto;
  }

  .card-title {
    background-color: rgb(102, 183, 250);
    height: 7vh;
  }

  .fas {
    margin-right: 3vw;
    margin-bottom: 2vh;
  }

  .selected {
    margin-left: 8vw;
  }

  img {
    max-height: 14rem;
    max-width: 15rem;
  }

  i {
    cursor: pointer;
  }
</style>