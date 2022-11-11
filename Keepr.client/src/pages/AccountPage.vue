<template>
  <div class="about text-center">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <img :src="account.imgUrl" alt="accountimg" class="forcedImg2">
        </div>
        <div class="col-md-3 col-lg-12">
          <img class="rounded-circle ms-2 mb-1" :src="account.picture" alt="" />

          <div class="col-md-3 col-lg-12">
            <button class="btn-dark btn" data-bs-target='#editform-modal' data-bs-toggle='modal'>EditForm</button>
            <h1> {{ account.name }}</h1>
          </div>
          <div class="col-md-3 col-lg-12">
            <span>{{ myVaults?.length }}</span>
          </div>

        </div>
        <div class="row">
          <h5>Vaults</h5>
          <div class="col-md-3 vault" v-for="v in myVaults" :key="v.id">
            <VaultCard :vault="v" />
          </div>
        </div>
        <!-- <div class="row">
        <h5>Keeps</h5>
        <div class="col-md-6 keep" v-for="m in myKeep" :key="m.id">
          <KeepsCard :keep="m" />
        </div>
      </div> -->
      </div>
    </div>
  </div>
</template>

<script>

import { computed, watchEffect } from 'vue'
import { AppState } from '../AppState'
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";




export default {
  setup() {

    watchEffect(() => {
      AppState.myKeep;
      AppState.myVault;
    })


    return {
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      myKeep: computed(() => AppState.myKeep == AppState.ProfileKeep)
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

.profpic {
  position: absolute;
}

.forcedImg {
  height: 300px;
  width: auto;
  object-fit: cover;
}

.forcedImg2 {
  height: 500px;
  width: auto;
  object-fit: cover;
}
</style>
