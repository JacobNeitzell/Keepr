<template>
  <div class="profile">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12" v-if="keep">
          <img :src="keep?.creator.imgurl" alt="profile-cover-img">
        </div>
        <h3 class="text-secondary mb-md-0">@{{ keep?.creator.name.split("@")[0] }}</h3>
      </div>
      <div class="row">
        <div class="col-md-3 col-lg-12">
          <h2>Vaults</h2>
          <VaultCard />
        </div>
      </div>
      <div class="row">
        <h2>Keeps</h2>
        <KeepsCard :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";
import { Account } from "../models/Account";
import { Keep } from "../models/Keep.js";

export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup(props) {
    return {
      creator: computed(() => AppState.account.id == props.keep.id),
    };
  },
  components: { KeepsCard, VaultCard }
}
</script>
