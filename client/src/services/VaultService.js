import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";


class VaultService {

  async getVaultsById(vaultId) {

    const response = await api.get(`api/values/${vaultId}`)
    logger.log(response.data)
    // const vault = new Vault(response.data)
    // AppState.vaults = vault
    //? Get vault by ID
  }
  // async getEventById(eventId) {
  //   AppState.activeEvent = null
  //   const response = await api.get(`api/events/${eventId}`)

  //   const event = new Event(response.data)
  //   AppState.activeEvent = event
  // }

}

export const vaultService = new VaultService();
