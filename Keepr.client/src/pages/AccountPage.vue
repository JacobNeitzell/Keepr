<template>
  <div class="about text-center">
    <div class="container-fluid">
      <div class="row">
        <h1>Welcome {{ account.name }}</h1>
        <img class="rounded-circle ms-2 mb-1" :src="account.picture" alt="" />
        <span>Vaults count, Keeps count</span>
      </div>
      <div class="row">
        <h5>Vaults</h5>
        <div class="col-md-3 vault" v-for="v in myVault" :key="v.id">
          <VaultCard :vault="v" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-6 keep" v-for="k in myKeep">
          <h5>Keeps</h5>
          <KeepsCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";


export default {
  setup() {




    return {
      account: computed(() => AppState.account),
      myVault: computed(() => AppState.myVault),
      myKeep: computed(() => AppState.myKeep)
    };
  },
  components: { VaultCard, KeepsCard }
}
</script>

<style scoped>
.vault {
  width: 195px;
  height: 131px;
}

img {
  max-width: 100px;
}
</style>
