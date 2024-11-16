using System.Reflection.Metadata;

List<string> kortlek = new List<string>{
    "Ess", "Ess", "Ess", "Ess", "2", "2", "2", "2", "3", "3", "3", "3",
    "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6",
    "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
    "10", "10", "10", "10", "Knäkt", "Knäkt", "Knäkt", "Knäkt",
    "Dam", "Dam", "Dam", "Dam", "Kung", "Kung", "Kung", "Kung"
};

/*  ändra tid på linje 17 och 296 till något heltal, det ändrar hastigheten av texten.
    ändra även if() på linje 78 till true om du vill spela */
int poäng1 = 0;
int poäng2 = 0;
int poäng3 = 0;
int poäng4 = 0;

int tid = 0;
int föratt = 0;
int frågavilken;
int vemdunyssfråga = 0;
int spelareval = 0; //används bara för att veta vem de frågar kan nog sätta i en method
string check = "";

Random r = new Random();

int antalKortPerSpelare = 7;
List<string> spelare1 = new List<string>{};
List<string> spelare2 = new List<string>{};
List<string> spelare3 = new List<string>{};
List<string> spelare4 = new List<string>{};




// Dela ut kort till spelare
for (int i = 0; i < antalKortPerSpelare; i++){
    spelare1.Add(DraKort(kortlek, r));
    spelare2.Add(DraKort(kortlek, r));
    spelare3.Add(DraKort(kortlek, r));
    spelare4.Add(DraKort(kortlek, r));
    
}

// Skriv ut spelarnas händer
string mes1 = "Du: ";
string mes2 = "Spelare 2: ";
string mes3 = "Spelare 3: ";
string mes4 = "Spelare 4: ";

sakta(mes1,tid);
    vadhardeförkort(spelare1);
sakta(mes2,tid);
    vadhardeförkort(spelare2);
sakta(mes3,tid);
    vadhardeförkort(spelare3);
sakta(mes4,tid);
    vadhardeförkort(spelare4);

string mes5 = ".";
for(int i = 0; i != 4; i++){
    sakta(mes5,tid);
}


while(spelare1.Count != 0 || spelare2.Count != 0 || spelare3.Count != 0 || spelare4.Count != 0){
    //spelare 1

    if(spelare1.Count != 0){
        do{
            Console.WriteLine("Spelare 1 ");
            Console.WriteLine();
            if(kortlek.Count != 0){
                spelare2.Add(DraKort(kortlek,r));
            }

            if(1==1){
                
                do{
                    if(spelare1.Count == 0){
                        break;
                    }
                    
                    string mes6 = "Dina kort";
                    sakta(mes6,tid);
                    vadhardeförkort(spelare1);

                    string mes7 = "Vilket kort vill du ta";
                    sakta(mes7,tid);
                    string kortetduvillha = Console.ReadLine();
                    check = kortetduvillha;
                    if(!spelare1.Contains(check)){
                        string mes8 = "Du har inte det kortet, välj ett annat";
                        sakta(mes8, tid);
                    }
                }while(!spelare1.Contains(check));
                if(spelare1.Count == 0){
                    break;
                }
            
                string mes9 = "Vem vill du fråga, spelare 2, 3 eller 4. Skriv 2, 3 eller 4";
                sakta(mes9, tid);

                frågavilken = int.Parse(Console.ReadLine());
                
            }
            else{
                aivälja(ref spelareval, 1, ref vemdunyssfråga);
                frågavilken = spelareval;
            }

            if(frågavilken == 2){
                drakort_frånhand(frågavilken, ref spelare1, ref spelare2, check, ref föratt);
            }
            if(frågavilken == 3){
                drakort_frånhand(frågavilken, ref spelare1, ref spelare3, check, ref föratt);
            }
            if(frågavilken == 4){
                drakort_frånhand(frågavilken, ref spelare1, ref spelare4, check, ref föratt);
            }
            harde4(ref spelare1, ref poäng1);
        }while(föratt == 1);
    }

    if(kortlek.Count != 0){
        spelare1.Add(DraKort(kortlek, r));
    }
    harde4(ref spelare1, ref poäng1);

    // spelare1 2

    //vilket kort de vill ha
    if(kortlek.Count != 0){
        spelare2.Add(DraKort(kortlek,r));
    }
    int handantalkort = spelare2.Count;
    if(handantalkort != 0){
        check = spelare2[r.Next(0,handantalkort)];
    }

    //vilken spelare de frågar
    if(spelare2.Count != 0){
        do{
            Console.WriteLine("Spelare 2 ");
            Console.WriteLine();
            aivälja(ref spelareval, 2, ref vemdunyssfråga);
            frågavilken = spelareval;

            if(frågavilken == 1){
                drakort_frånhand(frågavilken, ref spelare2, ref spelare1, check, ref föratt);
            }
            if(frågavilken == 3){
                drakort_frånhand(frågavilken, ref spelare2, ref spelare3, check, ref föratt);
            }
            if(frågavilken == 4){
                drakort_frånhand(frågavilken, ref spelare2, ref spelare4, check, ref föratt);
            }
            harde4(ref spelare2, ref poäng2);
        }while(föratt==1);
    }

    if(kortlek.Count != 0){
        spelare2.Add(DraKort(kortlek, r));
    }
    harde4(ref spelare2, ref poäng2);

    // spelare 3

    //vilket kort de vill ha
    if(kortlek.Count != 0){
        spelare3.Add(DraKort(kortlek,r));
    }
    handantalkort = spelare3.Count;
    if(handantalkort != 0){
        check = spelare3[r.Next(0,handantalkort)];
    }

    //vilken spelare de frågar
    if(spelare3.Count != 0){
        do{
            Console.WriteLine("Spelare 3 ");
            Console.WriteLine();
            aivälja(ref spelareval, 3, ref vemdunyssfråga);
            
            frågavilken = spelareval;
            if(frågavilken == 1){
                drakort_frånhand(frågavilken, ref spelare3, ref spelare1, check, ref föratt);
            }
            if(frågavilken == 2){
                drakort_frånhand(frågavilken, ref spelare3, ref spelare2, check, ref föratt);
            }
            if(frågavilken == 4){
                drakort_frånhand(frågavilken, ref spelare3, ref spelare4, check, ref föratt);
            }
            harde4(ref spelare3, ref poäng3);
        }while(föratt == 1);
    }

    if(kortlek.Count != 0){
        spelare3.Add(DraKort(kortlek, r));
    }
    harde4(ref spelare3, ref poäng3);

    // spelare1 4

    //vilket kort de vill ha
    if(kortlek.Count != 0){
        spelare4.Add(DraKort(kortlek,r));
    }
    handantalkort = spelare4.Count;
    if(handantalkort != 0){
        check = spelare4[r.Next(0,handantalkort)];
    }

    //vilken spelare de frågar
    if(spelare4.Count != 0){
        do{
            Console.WriteLine("Spelare 4 ");
            Console.WriteLine();
            aivälja(ref spelareval, 4, ref vemdunyssfråga);

            frågavilken = spelareval;
            if(frågavilken == 1){
                drakort_frånhand(frågavilken, ref spelare4, ref spelare1, check, ref föratt);
            }
            if(frågavilken == 2){
                    drakort_frånhand(frågavilken, ref spelare4, ref spelare2, check, ref föratt);
            }
            if(frågavilken == 3){
                drakort_frånhand(frågavilken, ref spelare4, ref spelare3, check, ref föratt);
            }
            harde4(ref spelare4, ref poäng4);
        }while(föratt == 1);
    }

    if(kortlek.Count != 0){
        spelare4.Add(DraKort(kortlek, r));
    }
    harde4(ref spelare4, ref poäng4);
}

sakta(mes1,tid);
    Console.WriteLine(poäng1 + " poäng");
    Console.WriteLine();
sakta(mes2,tid);
    Console.WriteLine(poäng2 + " poäng");
    Console.WriteLine();
sakta(mes3,tid);
    Console.WriteLine(poäng3 + " poäng");
    Console.WriteLine();
sakta(mes4,tid);
    Console.WriteLine(poäng4 + " poäng");
    Console.WriteLine();

static void sakta(string mes, int tid){
    foreach (char c in mes){
        Console.Write(c);
        Thread.Sleep(tid);
    }
    Console.WriteLine();
}

static void aivälja(ref int spelareval, int vemfrågar, ref int vemdunyssfråga){
            Random r = new Random();
            spelareval = r.Next(1,5);
            int plusminus;

            if(spelareval == vemfrågar){
                plusminus = r.Next(1,3);
                if(plusminus == 1){
                    if(spelareval != 1){
                        spelareval--;
                        if(spelareval == vemdunyssfråga){
                            if(spelareval != 1){
                                spelareval--;
                            }
                            else{
                                spelareval += 2;
                            }
                        }
                    }
                    else{
                        spelareval++;
                        if(spelareval == vemdunyssfråga){
                            spelareval++;
                        }
                    }
                }
                else{
                    if(spelareval != 4){
                        spelareval++;
                        if(spelareval == vemdunyssfråga){
                            if(spelareval != 4){
                                spelareval++;
                            }
                            else{
                                spelareval -= 2;
                            }
                        }
                    }
                    else{
                        spelareval--;
                        if(spelareval == vemdunyssfråga){
                            spelareval--;
                        }
                    }
                }
            }
        }

static void drakort_frånhand(int vemdufrågar, ref List<string> få_hand, ref List<string> ta_hand, string check, ref int föratt){
    int antal = 0;
    int tid = 0;
    string mes1 = "Spelare " + vemdufrågar+ " hade inga " + check +", dra från sjön";
    string[] anta = ["Null", "en ", "två ", "tre "];
    if(ta_hand.Contains(check)){
    
        do{
            ta_hand.Remove(check);
            få_hand.Add(check);
            antal++;
        }while(ta_hand.Contains(check));
        string mes2 = "spelare " + vemdufrågar + " Hade " + anta[antal] + check;
        sakta(mes2, tid);
        föratt = 1;    
    }
    else{
        föratt = 0;
        sakta(mes1, tid);
    }
}

static string DraKort(List<string> kortlek, Random r){
    int index = r.Next(kortlek.Count);         // Dra ett slumpmässigt index
    string kort = kortlek[index];           // Få kortet på det indexet
    kortlek.RemoveAt(index);                // Ta bort kortet från kortleken
    return kort;                            // Returnera kortet
}

static void vadhardeförkort(List<string> spelare){
    foreach(string dinhand in spelare){
        Console.Write(dinhand + " ");
        Thread.Sleep(50);
    }
    Console.WriteLine();
    Console.WriteLine();
}

static void harde4(ref List<string> hand, ref int poäng){
    string[] k13 = {"Ess","2","3","4","5","6","7","8","9","10","Knäkt","Dam","Kung"};
    for(int a = 0; a !=13; a++){
        int harde4 = hand.FindAll(kort => kort == k13[a]).Count;
        if(harde4 == 4){
            hand.RemoveAll(kort => kort == k13[a]);
            poäng++;
        }
    }
}

static void fel(string fel){
    Console.WriteLine("fel i "+fel);
}