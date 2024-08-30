export class Vault {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.img = data.img;
    this.isPrivate = data.isPrivate;
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creatorId = data.creatorId
  }
  get backgroundImage() {
    return `url(${this.img})`
  }
}
