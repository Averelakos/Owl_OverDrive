import { Injectable } from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams} from "@angular/common/http";
import { CreateGameDto, CreateReleaseDateDto } from "../types/game/create-game";

@Injectable()
export class GameService{
  uri: string = 'Game'
  baseUrl = environment.apiUrl+this.uri;
  constructor(private readonly formBuilder: FormBuilder, private http: HttpClient){}

  initForm(): FormGroup {
      return this.formBuilder.group({
        general: this.formBuilder.group({
          name:[null],
          description:[null],
          image:[null],
          updateGameType: [null],
          updatedGameId:[null],
          gameStatus:[null],
          gameEdition:this.formBuilder.group({
            baseGame: [null],
            editionTitle: [null]
          }),
          gameAlternativeNames:this.formBuilder.array([])
        }),
        localization: this.formBuilder.array([]),
        categorization: this.formBuilder.group({
          genre:[null],
          theme:[null],
          perspectives:[null],
          gameMode:[null],
          multiplayerModes: this.formBuilder.array([])
        }),
        releaseDates: this.formBuilder.array([]),
        websites: this.formBuilder.group({
          steam: [null],
          epic: [null],
          appStorePhone: [null],
          itch: [null],
          gog:[null],
          googlePlay:[null],
          appStoreTablet: [null],
          official: [null],
          twitch: [null],
          youtube: [null],
          facebook: [null],
          twitter:[null],
          instagram:[null],
          discord: [null],
          reddit:[null]
        }),
        companies: this.formBuilder.array([]),
        storyline: [null],
        supportedLanguage: this.formBuilder.group({
          audio:[null],
          subtitle:[null],
          interface:[null]
        })
      })
  }

  general(gameForm: FormGroup) {
    return gameForm.get('general') as FormGroup
  }

  releaseDates(gameForm: FormGroup) {
    return gameForm.get('releaseDates') as FormArray
  }

  gameEdition(gameForm: FormGroup) {
    return this.general(gameForm).get('gameEdition') as FormGroup
  }

  createModel(gameForm: FormGroup):CreateGameDto {
    let model: CreateGameDto = {
      name: this.general(gameForm).get('name')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      updateGameType: this.general(gameForm).get('updateGameType')?.value,
      updatedGameId : this.general(gameForm).get('updatedGameId')?.value, 
      gameEdition:null,
      alternativeNames: [],
      releaseDates: this.converToCreateReleaseDateDto(this.releaseDates(gameForm)),
      websites: []
    }

    // General game edition
    if (this.gameEdition(gameForm).get('editionTitle')?.value!= null && this.gameEdition(gameForm).get('baseGame')?.value != null) {
      model.gameEdition = {
        editionTitle: this.gameEdition(gameForm).get('editionTitle')?.value,
        parentGameId: this.gameEdition(gameForm).get('baseGame')?.value,
      }
    }

    // General game alternative name
    if (this.general(gameForm).get('gameAlternativeNames')?.value.length > 0) {
      model.alternativeNames = this.general(gameForm).get('gameAlternativeNames')?.value
    }

    return model;
  }

  converToCreateReleaseDateDto(list: FormArray) {
    let convertedResults: Array<CreateReleaseDateDto> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
        entry.releases.forEach(release => {
          let tempReleaseDate: CreateReleaseDateDto = {
            platformId: entry.platform,
            date: release.date,
            regionId: release.region,
            status: release.status
          }

          convertedResults.push(tempReleaseDate)
        });
      });
    }
    return convertedResults;
  }

  searchParentGame(searchInput: string){
    const body = JSON.stringify(searchInput)
    const params = new HttpParams().set('searchInput', searchInput)
    return this.http.post<any>(this.baseUrl + '/Search', null, { params })
  }

  createNewGame(model: CreateGameDto){
    return this.http.post<any>(this.baseUrl + '/AddGame',model)
  }

}