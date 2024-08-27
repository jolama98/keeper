import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "../AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {
  setActiveKeep(keep) {
    AppState.setActiveKeep = keep
  }


  async destroyKeep(keepId) {
    const response = await api.delete(`api/keeps/${keepId}`)
    const keepDelete = AppState.keeps.findIndex(KeepToDelete => KeepToDelete.id == keepId)
    AppState.keeps.slice(keepDelete, 1)
  }

  async getAllKeeps() {
    const response = await api.get('api/keeps')
    const keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
    AppState.keeps = keeps
  }
}

export const keepsService = new KeepsService()
