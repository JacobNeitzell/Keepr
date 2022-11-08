<template>
  <div class="masonry-with-columns">
    <div v-for="k in keep">
      <KeepsCard :keep="k" :key="k.id" />
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
      account: computed(() => AppState.account)


    }
  }
}
</script>

<style scoped lang="scss">
.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;

  div {
    display: inline-block;
    width: 100%;
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
