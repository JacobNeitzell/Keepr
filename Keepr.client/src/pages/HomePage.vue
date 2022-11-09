<template>
  <div class="masonry-with-columns">
    <div v-for="k in keep">
      <KeepsCard :keep="k" :key="k.id" />
      <KeepModal :keep="activeKeep" />
    </div>
  </div>

</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    async function GetKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(() => { GetKeeps() })
    return {
      keep: computed(() => AppState.keep),
      account: computed(() => AppState.account),
      activeKeep: computed(() => AppState.activeKeep)


    }
  }
}
</script>

<style scoped lang="scss">
.masonry-with-columns {
  columns: 4 165.50px;


  div {
    width: 150px;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  }

  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100)+px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
