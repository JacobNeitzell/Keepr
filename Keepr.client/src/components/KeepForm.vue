<template>
  <div class="KeepForm">
    <form @submit.prevent="CreateKeep()">
      <div class="modal-body">
        <div class="form-floating mb-3">
          <input v-model="editable.name" required type="text" class="form-control" id="keepName" placeholder="Name...">
          <label for="keepName">Keep Name</label>
        </div>
        <div class="form-floating mb-3">
          <textarea v-model="editable.description" required type="text" class="form-control" id="keepDescription"
            placeholder="Description...">
                </textarea>
          <label for="floatingDescription">Description</label>
        </div>
        <div class="form-floating mb-3">
          <input v-model="editable.img" required type="url" class="form-control" id="keepImg" placeholder="Image...">
          <label for="keepImg">Keep Image</label>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="submit" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </form>

  </div>
</template>


<script>
import { Modal } from "bootstrap";
import { ref } from "vue";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})

    return {
      editable,
      async CreateKeep() {
        try {
          await keepsService.CreateKeep(editable.value)
          editable.value = {};
          Modal.getOrCreateInstance('#keepForm-modal').hide()
        } catch (error) {
          Pop.error(error)
        }
      }





    }
  }
}
</script>


<style lang="scss" scoped>

</style>