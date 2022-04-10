<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <h2 class="mx-3">AllSpice</h2>
    </router-link>
    <button
      class="btn btn-success"
      data-bs-target="#myModal"
      data-bs-toggle="modal"
    >
      Add Recipe
    </button>
    <Modal id="myModal">
      <template #title>Add a Recipe</template>
      <template #body>
        <form @submit.prevent="createRecipe">
          <div class="row p-2">
            <input
              v-model="editable.title"
              class="col-12 mt-1"
              type="text"
              placeholder="Title"
            />
            <input
              v-model="editable.subTitle"
              class="col-12 mt-1"
              type="text"
              placeholder="Subtitle"
            />
            <input
              v-model="editable.category"
              class="col-12 mt-1"
              type="text"
              placeholder="Category"
            />
            <input
              v-model="editable.picture"
              class="col-12 mt-1"
              type="text"
              placeholder="Picture"
            />
            <button class="btn btn-success mt-3">Create!</button>
          </div>
        </form>
      </template>
    </Modal>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div
      class="collapse navbar-collapse d-flex justify-content-end"
      id="navbarText"
    >
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import { ref } from "@vue/reactivity";
import { logger } from "../utils/Logger";
import { recipesService } from "../services/RecipesService";
export default {
  setup() {
    const editable = ref({});
    return {
      editable,
      async createRecipe() {
        try {
          await recipesService.createRecipe(editable.value)
        } catch (error) {
          logger.error(error)
        }
      }
    };
  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
