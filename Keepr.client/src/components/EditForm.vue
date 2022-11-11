<template>
  <div class="component">
    <form @submit.prevent="editAccount()">
      <div class="modal-body">
        <div class="form-floating mb-3">
          <input v-model="editable.name" required type="text" class="form-control" id="accountName"
            placeholder="Name...">
          <label for="accountName">Account Name</label>
        </div>
        <div class="form-floating mb-3">
          <input v-model="editable.imgUrl" required type="url" class="form-control" id="accountImgUrl"
            placeholder="ImgUrl..." />
          <label for="floatingDescription">Img Url</label>
        </div>
        <div class="form-floating mb-3">
          <input v-model="editable.picture" required type="url" class="form-control" id="accountPicture"
            placeholder="Image...">
          <label for="accountPicture">Profile Picture</label>
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
import { accountService } from "../services/AccountService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async editAccount() {
        try {
          await accountService.UpdateAccount(editable.value)
          editable.value = {};
          Modal.getOrCreateInstance('#editform-modal').hide()
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